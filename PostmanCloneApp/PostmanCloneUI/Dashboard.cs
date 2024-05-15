using PostmanCloneLibrary;

namespace PostmanCloneUI;

public partial class Dashboard : Form
{
    private readonly IApiAccess api = new ApiAccess();
    public Dashboard()
    {
        InitializeComponent();
        httpVerbSelection.SelectedItem = "GET";
    }

    private async void callAPI_Click(object sender, EventArgs e)
    {
        systemStatus.Text = "Calling API...";
        resultsText.Text = string.Empty;

        if (api.IsValidUrl(apiText.Text) == false)
        {
            systemStatus.Text = "Invalid URL";
            return;
        }

        try
        {
            var httpVerb = httpVerbSelection.SelectedItem as string;
            if (Enum.TryParse(httpVerb, out HttpAction action))
            {
                HttpContent content = new StringContent(bodyText.Text);
                resultsText.Text = await api.CallApiAsync(apiText.Text, content, true, action);
                callData.SelectedTab = resultsTab;
            }
            
            systemStatus.Text = "Ready";
        }
        catch (Exception ex)
        {
            resultsText.Text = "Error: " + ex.Message;
            systemStatus.Text = "Error";
        }
    }
}
