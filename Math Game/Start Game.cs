using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Game
{
    public partial class Start_Game : Form
    {
  StGame sGame;
     public   char Option;
        decimal Rounds;
        float Resulte;
        int RandomNumber;
        enum enOptionTye { Plus=1,Mines=2,Multi=3,Divid=4};
        enum enQutionlevel { Eazy=1,Midum=2,Hurd=3};

        struct StGame
        {
            public int RihtAnsCounter;
            public int ErrAnsCounter;
            public int RoundConter;
            public string NameOption;
            public string nameLevelQution;
            public enOptionTye eOption;
            public enQutionlevel eQutionlevel;
        }
        public Start_Game(string LaelName,string NameOption,string DiffclutyLevel,decimal Round)
        {
            InitializeComponent();
            labName.Text = LaelName;
            labDiffLe.Text = DiffclutyLevel;
            labOpTy.Text = NameOption;
            Rounds= Round;
       
        }

        private void Start_Game_Load(object sender, EventArgs e)
        {
            sGame.RoundConter = 1;
            labTime.Text = DateTime.Now.ToString("HH:MM tt");
            ResultrOptin();
            QutionTyep();
            StartGame();
        }
        private enOptionTye OptionMix()
        {Random random = new Random();
            int NumberOption = random.Next(1, 5);
            switch (NumberOption)
            {
                case 1:
                    sGame.eOption = enOptionTye.Plus;
                    break;
                case 2:
                    sGame.eOption = enOptionTye.Mines;
                    break;
                case 3:
                    sGame.eOption = enOptionTye.Multi;
                    break;
                case 4:
                    sGame.eOption = enOptionTye.Divid;
                    break;
            }
            return sGame.eOption;

        }
        private void ResultrOptin()
        {
            sGame.NameOption = labOpTy.Text;
            switch (sGame.NameOption)
            {
                case "Plus":
                    sGame.eOption = enOptionTye.Plus;
                    break;
                case "Mult":
                    sGame.eOption = enOptionTye.Multi;
                    break;
                case "Divide":
                    sGame.eOption = enOptionTye.Divid;
                    break;
                case "Mins":
                    sGame.eOption = enOptionTye.Mines;
                    break;
                default:

                    sGame.eOption = OptionMix();
                    break;
            }

        }
        private char OptionTyp()
        {
            
            switch (sGame.eOption)
            {
                case enOptionTye.Plus:
                    Option= '+';
                    break;
                case enOptionTye.Mines:
                    Option = '-';
                    break;
                case enOptionTye.Multi:
                    Option = '*';
                    break;
                case enOptionTye.Divid:
                    Option = '/';
                    break;
            }
            return Option;
        }
        private void QutionTyep()
        {
            sGame.nameLevelQution = labDiffLe.Text;

            switch (sGame.nameLevelQution)
            {
                case "Eazy":
                    sGame.eQutionlevel= enQutionlevel.Eazy;
                    break;
                case "Midum":
                    sGame.eQutionlevel = enQutionlevel.Midum;
                    break;
                case "Diffcult":
                    sGame.eQutionlevel = enQutionlevel.Hurd;
                    break;
            }
        }

        private int CreatQuntions()
        {
            Random random = new Random();

            switch (sGame.eQutionlevel)
            {
                case enQutionlevel.Eazy:
                  RandomNumber=random.Next(1,10);
                    break;
                case enQutionlevel.Midum:
                    RandomNumber = random.Next(10, 50);
                    break;
                case enQutionlevel.Hurd:
                    RandomNumber = random.Next(50,100);
                    break;
            }

            return RandomNumber;
        }

        private void QuntionPerstion()
        {
            int num1=CreatQuntions();
            int num2=CreatQuntions();
            
            switch(OptionTyp())
            {
                case '+':
                    labGENQution.Text = num1.ToString() + "+" + num2.ToString();
                    Resulte = num1 + num2;
                    break;

                case '-':
                    labGENQution.Text = num1.ToString() + "-" + num2.ToString();
                    Resulte = num1 - num2;
                    break;

                case '*':
                    labGENQution.Text = num1.ToString() + "*" + num2.ToString();
                    Resulte = num1 * num2;
                    break;

                case '/':
                    while (num2 == 0)
                        num2 = CreatQuntions();

                    labGENQution.Text = num1.ToString() + " / " + num2.ToString();
                    Resulte = (float)num1 / num2;
                    break;
                    
            }
        }


        private void CheckAnswer()
        {
            if (!int.TryParse(tXBAnswer.Text, out int userAnswer))
            {
                MessageBox.Show("الرجاء إدخال رقم صحيح.", "خطأ في الإدخال",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userAnswer != (int)Resulte)
            {
                sGame.ErrAnsCounter++;
                MessageBox.Show("الإجابة خاطئة. الإجابة الصحيحة هي = " + Resulte, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                labErrA.Text = sGame.ErrAnsCounter.ToString();
            }
            else
            {
                sGame.RihtAnsCounter++;
                labRightA.Text = sGame.RihtAnsCounter.ToString();
            }
        }


        private void NextRound()
        {
            if (sGame.RoundConter == Rounds)
            {
                MessageBox.Show("Game Over");
                btnNext.Enabled = false;
                btnChek.Enabled = false;
                return;
            }

            sGame.RoundConter++;
            StartGame();
        }

        private void StartGame()
        {
        
            labRound.Text=sGame.RoundConter.ToString()+"/"+ Rounds.ToString();
            QuntionPerstion();
        }

        private void btnChek_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextRound();
        }
    }
}


