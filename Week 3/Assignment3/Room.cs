using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Room
    {
        public Monster Monster { get; }
        public Question Question { get; }
        public bool PlayerWin { get; set; }
        public bool Discovered { get; set; }

        public Room(Monster monster, Question question, bool playerWin = false, bool discovered = false)
        {
            Monster = monster;
            Question = question;
            PlayerWin = playerWin;
            Discovered = discovered;
        }

        public string DisplayRoom()
        {
            return $"In the center of the room is a {Monster.Type}. The {Monster.Type} approaches you and asks you a riddle.{Environment.NewLine}{Question.DisplayQuestion()}";
        }

        public override string ToString()
        {
            return $"{Monster.ToString()}|{Question.ToString()}|{PlayerWin}|{Discovered}";
        }
    }
}
