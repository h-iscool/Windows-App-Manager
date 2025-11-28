using System;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

namespace DebugCli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private List<string> CommandHistory = new List<string>();

        private int CommandHistoryIndex = 0;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                print("> " + textBox1.Text + "\n", Color.Black);
                processCommand(textBox1.Text);

                textBox1.Text = "";

                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                if (CommandHistory.Count > 0)
                {
                    CommandHistoryIndex--;
                    if (CommandHistoryIndex < 0)
                    {
                        CommandHistoryIndex = 0;
                    }
                    textBox1.Text = CommandHistory[CommandHistoryIndex];
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.SelectionLength = 0;
                }
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                if (CommandHistory.Count > 0)
                {
                    CommandHistoryIndex++;

                    if (CommandHistoryIndex >= CommandHistory.Count)
                    {
                        CommandHistoryIndex = CommandHistory.Count;
                        textBox1.Text = "";
                    }
                    else
                    {
                        textBox1.Text = CommandHistory[CommandHistoryIndex];
                    }
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.SelectionLength = 0;
                }
                e.SuppressKeyPress = true;
            }

        }

        private void print(string text, Color color)
        {

            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            richTextBox1.SelectionColor = color;

            richTextBox1.AppendText(text);

            richTextBox1.SelectionColor = richTextBox1.ForeColor;

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void clear()
        {
            richTextBox1.Text = "";
        }



        private void processCommand(string command)
        {
            CommandHistory.Add(command);
            CommandHistoryIndex = CommandHistory.Count;

            if (command.StartsWith("help", StringComparison.OrdinalIgnoreCase))
            {
                //print("hi chat\n", Color.Gold);
                print("Use /? after a command for more information.\n" +
                    "List of commands:\n" +
                    "[command] | [discription]\n" +
                    "about | gives information about this software" +
                    "cls | clears the screen\n" +
                    "endAllSelf | kills all `Windows Process Manager` processes (at same auth level)\n" +
                    "exit | kills this process\n" +
                    "help | displays this information\n" +
                    "pipe | a command to debug the pipe connection\n" +
                    "processes | a command to debug processes\n", Color.Black);
            }
            else if (command.StartsWith("endAllSelf", StringComparison.OrdinalIgnoreCase))
            {
                print("Killing all processes...\n", Color.Blue);
                try
                {
                    Process[] processes = Process.GetProcessesByName("Windows Process Manager");
                    foreach (Process process in processes)
                    {
                        process.Kill();
                    }
                }
                catch (Exception err)
                {
                    print(err.ToString() + "\n", Color.Red);
                }

            }
            else if (command.StartsWith("processes"))
            {
                if (command.Contains(" /?"))
                {
                    print("processes command help:\n" +
                        "[command argument] | [result]\n" +
                        "-ls | lists all running processes\n" +
                        "-killName [string] | kills all processes with that process name (at currnet auth level)\n" +
                        "-killId [int] | kills the process with the inputted ID (only works if the process is at the same auth level)\n" +
                        "-start [path] | attempts to start a process with the given path\n" +
                        "/? | gives this info\n" +
                        "", Color.Black);
                }
                else if (command.Contains(" -ls", StringComparison.OrdinalIgnoreCase))
                {
                    Process[] processes = Process.GetProcesses();
                    print("-----\n", Color.Orange);
                    foreach (Process process in processes)
                    {
                        print(process.ProcessName + "\n", Color.Orange);
                    }
                    print("-----\n", Color.Orange);
                }
                else if (command.Contains("-killId"))
                {
                    string idString = command.Split(new[] { "-killId" }, StringSplitOptions.None)[1].Trim();
                    print("Killing " + idString + "\n", Color.Black);
                    try
                    {
                        Process ToKill = Process.GetProcessById(int.Parse(idString));
                        ToKill.Kill();
                    }
                    catch (Exception err)
                    {
                        print(err.ToString() + "\n", Color.Red);
                    }
                }
                else if (command.Contains("-killName"))
                {
                    string nameStr = command.Split(new[] { "-killId" }, StringSplitOptions.None)[1].Trim();
                    print("Killing " + nameStr + "\n", Color.Black);
                    try
                    {
                        Process[] ToKill = Process.GetProcessesByName(nameStr);
                        foreach (Process process in ToKill)
                        {
                            process.Kill();
                        }
                    }
                    catch (Exception err)
                    {
                        print(err.ToString() + "\n", Color.Red);
                    }
                }
                else if (command.Contains("-start"))
                {
                    try
                    {
                        // Get everything after "-start" and trim whitespace
                        string path = command.Split(new[] { "-start" }, StringSplitOptions.None)[1].Trim();

                        if (string.IsNullOrWhiteSpace(path))
                        {
                            print("No path provided!\n", Color.Red);
                            return;
                        }

                        // Start the process
                        Process.Start(path);
                        print($"Started process: {path}\n", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        print($"Failed to start process: {ex.Message}\n", Color.Red);
                    }
                }


            }
            else if (command.StartsWith("cls", StringComparison.OrdinalIgnoreCase))
            {
                clear();
            }
            else if (command.StartsWith("exit", StringComparison.OrdinalIgnoreCase))
            {
                Process.GetCurrentProcess().Kill(); //none of these kill only this TwT but whatever
                //Environment.Exit(0);
                //Application.Exit();

            }
            else if (command.StartsWith("about", StringComparison.OrdinalIgnoreCase))
            {
                print("Version: 1.1.0\n" +
                    "Created by: a :3 floofhead on the internet\n" +
                    "ya... idk what to put here\n" +
                    "@w@\n" +
                    "heres a cat for ur troubles:\n" +
                    "-=^..^=-\n", Color.Black);
            }
            else if (command.StartsWith("pipe", StringComparison.OrdinalIgnoreCase))
            {
                if (command.Contains(" /?", StringComparison.OrdinalIgnoreCase))
                {
                    print("pipe command help:\n" +
                        "[command argument] | [result]\n" +
                        "-connectTest | trys to connect to the pipe then instantly closes the connection\n" +
                        "-send [string] | connects and writes to the pipe\n" +
                        "-info | gives info about the pipe connection\n" +
                        "-pipeCommands | lists all pipe server commands \n" +
                        "/? | gives this info\n", Color.Black);
                }
                else if (command.Contains(" -connectTest", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        using (NamedPipeClientStream client = new NamedPipeClientStream(
                            ".",
                            "WindowsProcessManagerUpdaterPipe",
                            PipeDirection.InOut
                            ))
                        {
                            client.Connect(5000);
                            string message = "connection test";
                            byte[] msgBytes = Encoding.UTF8.GetBytes(message);
                            client.Write(msgBytes, 0, msgBytes.Length);
                            byte[] buffer = new byte[256];
                            int bytesRead = client.Read(buffer, 0, buffer.Length);
                            string responce = Encoding.UTF8.GetString(buffer);
                            Debug.WriteLine(responce);
                            client.Close();
                            print("Pipe connected successfully!\n", Color.Green);

                        }
                    }
                    catch (Exception err)
                    {
                        print(err.ToString() + "\n", Color.Red);
                    }
                }
                else if (command.Contains("-send"))
                {
                    try
                    {
                        string message = command.Split(new[] { "-send" }, StringSplitOptions.None)[1].Trim();

                        //print(message+"\n", Color.Black);

                        if (Encoding.UTF8.GetBytes(message).Length > 255)
                        {
                            throw new Exception("message is too large to send");
                        }

                        using (NamedPipeClientStream client = new NamedPipeClientStream(
                            ".",
                            "WindowsProcessManagerUpdaterPipe",
                            PipeDirection.InOut
                            ))
                        {
                            client.Connect(5000);
                            byte[] msgBytes = Encoding.UTF8.GetBytes(message);
                            client.Write(msgBytes, 0, msgBytes.Length);
                            byte[] buffer = new byte[256];
                            int bytesRead = client.Read(buffer, 0, buffer.Length);
                            string responce = Encoding.UTF8.GetString(buffer);
                            client.Close();
                            print(responce + "\n", Color.Green);

                        }
                    }
                    catch (Exception err)
                    {
                        print(err.ToString() + "\n", Color.Red);
                    }
                }
                else if (command.Contains("-info", StringComparison.OrdinalIgnoreCase))
                {
                    print("Server Name: WindowsProcessManagerUpdaterPipe\n" +
                        "Client Name: .\n" +
                        "Direction: in/out\n" +
                        "", Color.Black);
                }
                else if (command.Contains("-pipeCommands"))
                {
                    print("pipe server commands:\n" +
                        "[command] | [action]\n" +
                        "updateCheck | checks for an update (responds 1 if avalable 0 if not)\n" +
                        "downloadAndInstall | downloads and installs the latest version of the app\n" +
                        "verify | checks if the required stuff exists\n" +
                        "", Color.Black);
                }
            }

            else
            {
                print("Command not recognised:\n" + command + "\nUse \"help\" for all the commands\n", Color.Red);
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
