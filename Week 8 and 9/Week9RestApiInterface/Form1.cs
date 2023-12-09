using System.Text.Json;

namespace Week9RestApiInterface
{
    public partial class Form1 : Form
    {
        APITest test = new APITest("http://ec2-3-17-29-162.us-east-2.compute.amazonaws.com/index.php");

        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            if(tb_fruit_name.Text.Trim() != string.Empty)
            {
                var response = await test.RunAddFruitTestAsync(tb_fruit_name.Text.Trim());

                var json = await response.Content.ReadAsStringAsync();
                var output = JsonSerializer.Deserialize<FruitResponse>(json);

                tb_output.Text += output.ToString();
                tb_fruit_name.Text = string.Empty;
            }
            else
            {
                tb_output.Text += $"No fruit name entered!{Environment.NewLine}{Environment.NewLine}";
            }
        }

        private void tb_output_TextChanged(object sender, EventArgs e)
        {
            tb_output.SelectionStart = tb_output.Text.Length;
            tb_output.ScrollToCaret();
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (tb_fruit_name.Text.Trim() != string.Empty)
            {
                var response = await test.RunRemoveFruitTestAsync(tb_fruit_name.Text);

                var json = await response.Content.ReadAsStringAsync();
                var output = JsonSerializer.Deserialize<FruitResponse>(json);

                tb_output.Text += output.ToString();
                tb_fruit_name.Text = string.Empty;
            }
            else
            {
                tb_output.Text += $"No fruit name entered!{Environment.NewLine}{Environment.NewLine}";
            }
            
        }

        private async void btn_get_Click(object sender, EventArgs e)
        {
            var response = await test.RunGetFruitTestAsync();

            var json = await response.Content.ReadAsStringAsync();
            var output = JsonSerializer.Deserialize<FruitResponse>(json);

            tb_output.Text += output.ToString();
            tb_fruit_name.Text = string.Empty;
        }

        private async void btn_dailys_Click(object sender, EventArgs e)
        {
            var response = await test.RunGetDailyTestAsync();

            var json = await response.Content.ReadAsStringAsync();
            var output = JsonSerializer.Deserialize<DailyResponse>(json);

            tb_output.Text += output.ToString();
            tb_fruit_name.Text = string.Empty;
        }
    }
}