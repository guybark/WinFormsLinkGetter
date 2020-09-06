using System;
using System.Windows.Forms;
using UIAInterop;

//This app will look for links on a web page that reference the same page, and export those links to a file 
//such that the links can be incorporated into Q&A pairs for an Azure QnAMaker knowledge base. 

//For example, say the link was "http://mysite.com/help#birds". The QnAMaker knowledge base will end up
//with a Q&&A pair whose question is "birds", and whose answer is "For details on birds, please visit birds",
//where the second instance of birds is the links to http://mysite.com/help#birds.

// The app is publicly available at https://github.com/guybark/WinFormsLinkGetter.

namespace WinFormsLinkGetter
{
    public partial class Form1 : Form
    {
        private CUIAutomation8 automation;

        // These UIA values are taken from:
        // https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-automation-element-propids
        // https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-control-pattern-propids
        // https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-controltype-ids
        // https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-controlpattern-ids

        private const int patternIdValue = 10002;
        private const int propertyIdControlType = 30003;
        private const int propertyIdName = 30005;
        private const int propertyIdValueValue = 30045;
        private const int controlTypeIdHyperlink = 50005;

        public Form1()
        {
            InitializeComponent();

            automation = new CUIAutomation8();

            // Let's get the ball rolling with a W3C web page.
            textBoxURL.Text = "https://w3c.github.io/aria-practices";

            // TODO: Investigate why the empty WebBrowser seems to be a keyboard trap.
            // For now, take it out of the tab order it doesn't have a page loaded.
            webBrowserPage.TabStop = false;

            // Make sure all controls have appropriate accessible names.
            checkedListBoxLinks.AccessibleName = "Links found"; // TODO: Remember to localized accessible names.
            webBrowserPage.AccessibleName = "Web page with links";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Step 1: Load up the target page in the app.
        private void buttonLoadURL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxURL.Text))
            {
                MessageBox.Show(this,
                    "Please provide an URL for the web page of interest.",
                    "Link Getter",
                    MessageBoxButtons.OK);

                return;
            }

            try
            {
                webBrowserPage.Navigate(new Uri(textBoxURL.Text));

                webBrowserPage.TabStop = true;
            }
            catch (Exception)
            {
                MessageBox.Show(this,
                    "Sorry, I wasn't able to navigate to that URL.",
                    "Link Getter",
                    MessageBoxButtons.OK);
            }
        }

        // Step 2: Find all the links of interest on the loaded page.
        private void buttonFindLinks_Click(object sender, EventArgs e)
        {
            checkedListBoxLinks.Items.Clear();

            if (webBrowserPage.Url == null)
            {
                MessageBox.Show(this,
                    "Please load the web page of interest.",
                    "Link Getter",
                    MessageBoxButtons.OK);

                labelLinkCount.Text = "No links found.";

                return;
            }

            // Get the UIA element for the webBrowser with the page of interest loaded.
            IUIAutomationElement elementBrowser = 
                automation.ElementFromHandle(webBrowserPage.Handle);

            // Build up a cache request for all the data we need, to reduce the time it 
            // takes to access the link data once with have the collection of links.
            IUIAutomationCacheRequest cacheRequest = automation.CreateCacheRequest();

            cacheRequest.AddProperty(propertyIdName);

            cacheRequest.AddPattern(patternIdValue);
            cacheRequest.AddProperty(propertyIdValueValue);

            // Assume the links have names as expected, and we don't need to 
            // search children of the links for names.
            cacheRequest.TreeScope = TreeScope.TreeScope_Element;

            // We want the collection of all links on the page.
            IUIAutomationCondition conditionControlView = automation.ControlViewCondition;
            IUIAutomationCondition conditionHyperlink = 
                automation.CreatePropertyCondition(
                    propertyIdControlType, controlTypeIdHyperlink);

            IUIAutomationCondition finalCondition = automation.CreateAndCondition(
                conditionControlView, conditionHyperlink);

            // TODO: Call FindAllBuildCache() in a background thread in case it takes 
            // a while. As it is, the app UI's going to freeze.

            // Now get the collection of links.
            IUIAutomationElementArray elementArray = elementBrowser.FindAllBuildCache(
                TreeScope.TreeScope_Descendants, finalCondition, cacheRequest);
            if (elementArray != null)
            {
                // Process each returned hyperlink element.
                for (int idxLink = 0; idxLink < elementArray.Length; ++idxLink)
                {
                    IUIAutomationElement elementLink = elementArray.GetElement(idxLink);

                    // Despite the fact that we've got the names of the UIA links, don't
                    // use that information here. Perhaps we will use it in the future.

                    IUIAutomationValuePattern valuePattern = 
                        (IUIAutomationValuePattern)elementLink.GetCurrentPattern(
                        patternIdValue);
                    if (valuePattern != null)
                    {
                        // We're only interested in references the page makes to itself.
                        string strValueLink = valuePattern.CachedValue;
                        var index = strValueLink.IndexOf('#');
                        if ((index > 0) && strValueLink.StartsWith(textBoxURL.Text))
                        {
                            checkedListBoxLinks.Items.Add(strValueLink);
                        }
                    }
                }
            }

            // Let's assume we'll want most of the links found.
            SetLinkCheckedState(true);

            labelLinkCount.Text = "Count of links found: " + 
                checkedListBoxLinks.Items.Count;
        }

        // Step 3: Export the link info to a tsv file.
        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (checkedListBoxLinks.Items.Count == 0)
            {
                MessageBox.Show(this,
                    "Please get some links to export first.",
                    "Link Getter",
                    MessageBoxButtons.OK);

                return;
            }

            // Get the target file to contain the info.
            var dlg = new SaveFileDialog();
            dlg.Title = "Export links to file";
            dlg.Filter = "Tab separated values|*.tsv";

            var result = dlg.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                // Prepare the file for all the link data.
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(dlg.FileName))
                {
                    // The first line in the file must match the expectations of QnAMaker.
                    string firstLine = "Question\tAnswer";
                    file.WriteLine(firstLine);

                    // Process each link we found.
                    for (int index = 0; index < checkedListBoxLinks.Items.Count; ++index)
                    {
                        if (checkedListBoxLinks.GetItemChecked(index))
                        {
                            string strValueLink = checkedListBoxLinks.Items[index].ToString();

                            var termIndex = strValueLink.IndexOf('#');
                            if (termIndex > 0)
                            {
                                string term = strValueLink.Substring(termIndex + 1);

                                string answer = "For details on " + term +
                                    ", please visit [" + term + "](" +
                                    strValueLink + ")";

                                file.WriteLine(term + "\t" + answer);
                            }
                        }
                    }
                }
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            SetLinkCheckedState(true);
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            SetLinkCheckedState(false);
        }

        private void SetLinkCheckedState(bool setChecked)
        {
            for (int i = 0; i < checkedListBoxLinks.Items.Count; i++)
            {
                checkedListBoxLinks.SetItemChecked(i, setChecked);
            }
        }
    }
}
