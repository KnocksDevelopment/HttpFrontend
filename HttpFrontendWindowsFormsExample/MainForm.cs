using System;
using System.Windows.Forms;
using HttpFrontend;

namespace HttpFrontendWindowsFormsExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonUnthreaded_Click(object sender, EventArgs e)
        {
            var request = new HttpRequest(this.textboxUrl.Text);
            var result = request.MakeUnthreadedRequest();
            textBoxSource.Text = result.Body;
        }

        private void buttonThreaded_Click(object sender, EventArgs e)
        {
            var request = new HttpRequest(this.textboxUrl.Text);
            request.OnSuccessfulRequest += (result) =>
            {
                textBoxSource.Text = result.Body;
            };
            request.OnFailedRequest += (exc) =>
            {
                textBoxSource.Text = exc.Message;
            };
            request.MakeThreadedRequest();
        }
    }
}
