using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace CraftyVision
{

    public partial class MainMenu : Form
    {
        private readonly HttpClient client = new HttpClient();
        private CancellationTokenSource cts = null;

        public MainMenu()
        {
            InitializeComponent();
            txtName.TextChanged += txtName_TextChanged;
            cmbRenderType.Items.AddRange(new string[] { "2D Head", "2D Skin Texture", "3D Head", "3D Body" });
            cmbRenderType.SelectedIndex = 0;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private async void btnRender_Click(object sender, EventArgs e)
        {
            string username = txtName.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please Enter Username");
                return;
            }

            string mojangUrl = $"https://api.mojang.com/users/profiles/minecraft/{username}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Mojang API'den UUID çek
                    HttpResponseMessage response = await client.GetAsync(mojangUrl);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Username Cannot Found");
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    var data = System.Text.Json.JsonDocument.Parse(json);
                    string uuid = data.RootElement.GetProperty("id").GetString();

                    string selectedType = cmbRenderType.SelectedItem.ToString();
                    string imageUrl = "";
                    string filename = "";

                    if (selectedType == "2D Head")
                    {
                        imageUrl = $"https://crafatar.com/avatars/{uuid}?size=512&overlay";
                        filename = $"{username}_2d_head.png";
                    }
                    else if (selectedType == "2D Skin Texture")
                    {
                        imageUrl = $"https://crafatar.com/skins/{uuid}?size=512&overlay";
                        filename = $"{username}_2d_skin_texture.png";
                    }
                    else if (selectedType == "3D Head")
                    {
                        imageUrl = $"https://crafatar.com/renders/head/{uuid}?size=512&overlay";
                        filename = $"{username}_3d_head.png";
                    }
                    else if (selectedType == "3D Body")
                    {
                        imageUrl = $"https://crafatar.com/renders/body/{uuid}?size=512&overlay";
                        filename = $"{username}_body.png";
                    }

                    //save desktop
                    var imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image img = Image.FromStream(ms);
                        picRender.Image = img;

                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string fullPath = Path.Combine(desktopPath, filename);
                        img.Save(fullPath);
                        MessageBox.Show($"Render Saved On Desktop:\n{filename}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Went Wrong:\n" + ex.Message);
                }
            }

        }
        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            cts?.Cancel();

            string username = txtName.Text.Trim();
            if (username.Length < 3)
            {
                picRealtimeRender.Image = null;
                return;
            }

            cts = new CancellationTokenSource();
            var token = cts.Token;

            // Debounce (50ms)
            Task.Delay(50, token).ContinueWith(async t =>
            {
                if (t.IsCanceled) return;
                await LoadSkinHeadAsync(username);
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private async Task LoadSkinHeadAsync(string username)
        {
            try
            {
                // Mojang API UUID
                string mojangUrl = $"https://api.mojang.com/users/profiles/minecraft/{username}";
                HttpResponseMessage response = await client.GetAsync(mojangUrl);
                if (!response.IsSuccessStatusCode)
                {
                    picRealtimeRender.Image = null;
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                var data = System.Text.Json.JsonDocument.Parse(json);
                string uuid = data.RootElement.GetProperty("id").GetString();

                string avatarUrl = $"https://crafatar.com/avatars/{uuid}?size=64&overlay";

                var imgBytes = await client.GetByteArrayAsync(avatarUrl);
                using (var ms = new MemoryStream(imgBytes))
                {
                    var img = Image.FromStream(ms);
                    picRealtimeRender.Image = new Bitmap(img); // picRTR show
                }
            }
            catch
            {
                picRealtimeRender.Image = null;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
