
namespace TypingTest
{
    public partial class Form1 : Form
    {
        string text = "lorem ipsum dolor sit amet consectetur adipiscing elit integer nec odio praesent libero sed cursus ante dapibus diam sed nisi nulla quis sem at nibh elementum imperdiet duis sagittis ipsum praesent mauris fusce nec tellus sed augue semper porta mauris massa vestibulum lacinia arcu eget nulla class aptent taciti sociosqu ad litora torquent per conubia nostra per inceptos himenaeos curabitur sodales ligula in libero sed dignissim lacinia nunc curabitur tortor pellentesque nibh aenean quam in scelerisque sem at dolor maecenas mattis sed convallis tristique sem proin ut ligula vel nunc egestas porttitor morbi lectus risus iaculis vel suscipit quis luctus non massa fusce ac turpis quis ligula lacinia aliquet mauris ipsum nulla metus metus ullamcorper vel tincidunt sed euismod in nibh quisque volutpat condimentum velit class aptent taciti sociosqu ad litora torquent per conubia nostra per inceptos himenaeos";
        String[] words;
        int counter = 0;
        int correct = 0, wrong = 0;
        int seconds = 60;
        int myIndex = 0;
        DialogResult dialog;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            myText.Enabled = false;
            exampleTextArea.ReadOnly = true;
            comboBox1.SelectedIndex = 0;
            dialog = new DialogResult();

            words = text.Split(" ");
            for (int i = 0; i < words.Length; i++)
            {
                exampleTextArea.Text += words[i] + " ";
            }
           
        }





        private void myText_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == ' ')
            {

                string writtenText = myText.Text.ToLower();
                myText.Clear();
                if ((sender as TextBox).SelectionStart == 0)
                {
                    e.Handled = (e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    e.Handled = false;
                }


                if (counter >= words.Length)
                {
                    MessageBox.Show("Index Out Of Range");
                }

                else
                {
                    if (writtenText == words[counter].ToLower())
                    {
                        correct++;
                        lblCorrect.Text = "CORRECT : " + correct.ToString();
                        exampleTextArea.Select(myIndex, words[counter].Length);
                        exampleTextArea.SelectionColor = Color.Green;
                        myIndex += words[counter].Length + 1;
                    }
                    else
                    {
                        wrong++;
                        lblWrong.Text = "WRONG : " + wrong.ToString();
                        exampleTextArea.Select(myIndex, words[counter].Length);
                        exampleTextArea.SelectionColor = Color.Red;
                        myIndex += words[counter].Length + 1;


                    }



                    counter++;
                    lblTotal.Text = "TOTAL : " + counter.ToString();
                }
            }

            if (counter > 145 && counter <= 146)
            {
                exampleTextArea.Select(exampleTextArea.Text.Length-1, 1);
                exampleTextArea.ScrollToCaret();
                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    seconds = 60;
                    break;
                case 1:
                    seconds = 120;
                    break;
                case 2:
                    seconds = 180;
                    break;
                default:
                    break;
            }


            if (timer1.Enabled)
            {
                timer1.Stop();
                myText.Enabled = false;
                button1.Text = "START";
                button1.BackColor = Color.Green;
                button1.ForeColor = Color.White;
            }
            else
            {
                timer1.Start();
                myText.Enabled = true;
                this.ActiveControl = myText;
                button1.Text = "STOP";
                button1.BackColor = Color.Red;
                button1.ForeColor = Color.White;
            }
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            seconds--;
            lblTimer.Text = seconds.ToString();
            if (seconds == 0)
            {
                timer1.Stop();
                button1.Text = "START";
                myText.Enabled = false;
                button1.BackColor = Color.Green;
                button1.ForeColor = Color.White;
                lblCorrect.Font = new Font("Arial", 15, FontStyle.Bold);
                lblWrong.Font = new Font("Arial", 15, FontStyle.Bold);
                lblTotal.Font = new Font("Arial", 15, FontStyle.Bold);
                dialog = MessageBox.Show("Time is over\n" + lblCorrect.Text + "\n" + lblWrong.Text + "\n" + lblTotal.Text, "OK", MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    button1.Enabled = false;
                    Thread.Sleep(5000);
                    Application.Restart();
                    Environment.Exit(0);
                }
                else
                {
                    button1.Enabled = false;
                    Thread.Sleep(5000);
                    Application.Restart();
                    Environment.Exit(0);
                }

            }
        }




    }
}
