using System;
using System.Collections.Generic;
using System.IO;

namespace Who_Wants_ToBe_A_Millioner
{
    public class Administration
    {
        private string password = "1234";

        // List<String> tempororyQuestionStore = new List<String>();
        List<QuestionModel> questionStore = new List<QuestionModel>();

        public Administration()
        {

        }


        public void checkThePassword(string password)
        {
            if (this.password.Equals(password))
            {
                getMenu();
            }
            else
            {

                Console.WriteLine("Password is not correct.");
            }
        }

        public void getMenu()
        {
            int optionResult;

            Console.WriteLine("" +
                "Press 1 for see all question \n" + 
                "Press 2 for view and edit question \n" +
                "Press 3 to add new question \n"+
                "Press 4 to remove question"
                );
            optionResult = int.Parse(Console.ReadLine());

            switch (optionResult)
            {
                case 1:
                    getAllQuestions();
                    break;
                case 2:
                    viewAndEditQuestions();
                    break;
                case 3:
                    addNewQuestion();
                    break;
                case 4:
                    removeQuestion();
                    break;
                default:
                    Console.WriteLine("Enter the valid number");
                    break;

            }
        }

        public void getAllQuestions()
        {
            string[] categories = new string[] {"Easy","Medium","Hard" };
            ///Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Easy.txt
            for (int k = 0; k < categories.Length; k++)
            {
                int i = 1;
                StreamReader reader = new StreamReader("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/"+categories[k]+".txt");
                
                while (reader.EndOfStream == false)
                {


                    QuestionModel newQuestion = new QuestionModel();
                    newQuestion.category = reader.ReadLine();
                    newQuestion.id = i;
                    newQuestion.questionBody = reader.ReadLine();
                    newQuestion.correctAnswer = reader.ReadLine();
                    newQuestion.optionA = reader.ReadLine();
                    newQuestion.optionB = reader.ReadLine();
                    newQuestion.optionC = reader.ReadLine();
                    newQuestion.optionD = reader.ReadLine();
                    
                    questionStore.Add(newQuestion);
                    i++;
                }
                
                reader.Close();
            }

            // get all question is working
            // ekstra bir a b c d şıkkı görünülüyor çözülecek
            foreach (var question in questionStore)
            {

                Console.WriteLine(question.id+") Category: "+question.category+"\n \n"+question.questionBody+"\n\n"+" A) "+question.optionA
                    + " B) " + question.optionB + " C) " + question.optionC + " D) " + question.optionD+"\n");
                
            }
        }

        public void viewAndEditQuestions()
        {
            getAllQuestions();

            Console.WriteLine("Hangi kategori de ki soruyu değiştirmek istiyorsunuz ? ");
            string category = Console.ReadLine();
            Console.WriteLine("Soru id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Yeni soruyu giriniz: ");
            string newQuestionBody = Console.ReadLine();
            editQuestion(category, id, newQuestionBody);
           
        }



        public void editQuestion(string category,int id, string newQuestionBody)
        {
            if(category.ToLower() == "easy")
            {

                foreach (var question in questionStore)
                {
                    if (question.category.Equals(category) && question.id == id)
                    {
                        question.questionBody = newQuestionBody;
                    }
                }

                File.WriteAllText("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Easy.txt", string.Empty);
                TextWriter tw = new StreamWriter("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Easy.txt");
                foreach (var question in questionStore)
                {
                    if (question.category.Equals("easy"))
                    {
                        
                        tw.WriteLine(question.category);
                        tw.WriteLine(question.questionBody);
                        tw.WriteLine(question.correctAnswer);
                        tw.WriteLine(question.optionA);
                        tw.WriteLine(question.optionB);
                        tw.WriteLine(question.optionC);
                        tw.WriteLine(question.optionD);
                    }
                }
                tw.Close();
            }
            else if (category.ToLower() == "medium")
            {
                foreach (var question in questionStore)
                {
                    if (question.category.Equals(category) && question.id == id)
                    {
                        question.questionBody = newQuestionBody;
                    }
                }

                File.WriteAllText("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Medium.txt", string.Empty);
                TextWriter tw = new StreamWriter("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Medium.txt");
                foreach (var question in questionStore)
                {
                    if (question.category.Equals("medium"))
                    {

                        tw.WriteLine(question.category);
                        tw.WriteLine(question.questionBody);
                        tw.WriteLine(question.correctAnswer);
                        tw.WriteLine(question.optionA);
                        tw.WriteLine(question.optionB);
                        tw.WriteLine(question.optionC);
                        tw.WriteLine(question.optionD);
                    }
                }
                tw.Close();
            }


            else
            {
                foreach (var question in questionStore)
                {
                    if (question.category.Equals(category) && question.id == id)
                    {
                        question.questionBody = newQuestionBody;
                    }
                }

                File.WriteAllText("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Hard.txt", string.Empty);
                TextWriter tw = new StreamWriter("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Hard.txt");
                foreach (var question in questionStore)
                {
                    if (question.category.Equals("hard"))
                    {

                        tw.WriteLine(question.category);
                        tw.WriteLine(question.questionBody);
                        tw.WriteLine(question.correctAnswer);
                        tw.WriteLine(question.optionA);
                        tw.WriteLine(question.optionB);
                        tw.WriteLine(question.optionC);
                        tw.WriteLine(question.optionD);
                    }
                }
                tw.Close();
            }
        }

        public void addNewQuestion()
        {
            List<QuestionModel> temporaryList = new List<QuestionModel>();

            Console.WriteLine("Hnagi kategoriye soru eklemek istiyorsunuz ?");
            string aCategoryType = Console.ReadLine();

            if (aCategoryType.ToLower().Equals("easy"))
            {
                // get all question easy file
                StreamReader reader = new StreamReader("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Easy.txt");

                while (reader.EndOfStream == false)
                {
                    QuestionModel question = new QuestionModel();

                    question.category = reader.ReadLine();
                    question.questionBody = reader.ReadLine();
                    question.correctAnswer = reader.ReadLine();
                    question.optionA = reader.ReadLine();
                    question.optionB = reader.ReadLine();
                    question.optionC = reader.ReadLine();
                    question.optionD = reader.ReadLine();
                    temporaryList.Add(question)
;                }
                reader.Close();

                foreach (var question in temporaryList)
                {

                    Console.WriteLine(question.id + ") Category: " + question.category + "\n \n" + question.questionBody + "\n\n" + " A) " + question.optionA
                        + " B) " + question.optionB + " C) " + question.optionC + " D) " + question.optionD + "\n");

                }

                
                Console.WriteLine("Question body");
                string aQuestionBody = Console.ReadLine();
                Console.WriteLine("Enter the correct answer: ");
                string aCorrectAnswer = Console.ReadLine();
                Console.WriteLine("Enter the option A: ");
                string aOptionA = Console.ReadLine();
                Console.WriteLine("Enter the option B: ");
                string aOptionB = Console.ReadLine();
                Console.WriteLine("Enter the option C: ");
                string aOptionC = Console.ReadLine();
                Console.WriteLine("Enter the option D: ");
                string aOptionD = Console.ReadLine();

                TextWriter writer = new StreamWriter("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Easy.txt",true);
                writer.WriteLine(aCategoryType);
                writer.WriteLine(aQuestionBody);
                writer.WriteLine(aCorrectAnswer);
                writer.WriteLine(aOptionA);
                writer.WriteLine(aOptionB);
                writer.WriteLine(aOptionC);
                writer.WriteLine(aOptionD);

                writer.Close();

                Console.WriteLine("Question is added ");
                getMenu();
            }
            else if (aCategoryType.ToLower().Equals("medium"))
            {
                // get all question easy file
                StreamReader reader = new StreamReader("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Medium.txt");

                while (reader.EndOfStream == false)
                {
                    QuestionModel question = new QuestionModel();

                    question.category = reader.ReadLine();
                    question.questionBody = reader.ReadLine();
                    question.correctAnswer = reader.ReadLine();
                    question.optionA = reader.ReadLine();
                    question.optionB = reader.ReadLine();
                    question.optionC = reader.ReadLine();
                    question.optionD = reader.ReadLine();
                    temporaryList.Add(question)
;
                }
                reader.Close();

                foreach (var question in temporaryList)
                {

                    Console.WriteLine(question.id + ") Category: " + question.category + "\n \n" + question.questionBody + "\n\n" + " A) " + question.optionA
                        + " B) " + question.optionB + " C) " + question.optionC + " D) " + question.optionD + "\n");

                }

                
                Console.WriteLine("Question body");
                string aQuestionBody = Console.ReadLine();
                Console.WriteLine("Enter the correct answer: ");
                string aCorrectAnswer = Console.ReadLine();
                Console.WriteLine("Enter the option A: ");
                string aOptionA = Console.ReadLine();
                Console.WriteLine("Enter the option B: ");
                string aOptionB = Console.ReadLine();
                Console.WriteLine("Enter the option C: ");
                string aOptionC = Console.ReadLine();
                Console.WriteLine("Enter the option D: ");
                string aOptionD = Console.ReadLine();

                TextWriter writer = new StreamWriter("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Medium.txt",true);
                writer.WriteLine(aCategoryType);
                writer.WriteLine(aQuestionBody);
                writer.WriteLine(aCorrectAnswer);
                writer.WriteLine(aOptionA);
                writer.WriteLine(aOptionB);
                writer.WriteLine(aOptionC);
                writer.WriteLine(aOptionD);

                writer.Close();

                Console.WriteLine("Question is added ");
                getMenu();
            }
            else
            {
                // get all question easy file
                StreamReader reader = new StreamReader("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Hard.txt");

                while (reader.EndOfStream == false)
                {
                    QuestionModel question = new QuestionModel();

                    question.category = reader.ReadLine();
                    question.questionBody = reader.ReadLine();
                    question.correctAnswer = reader.ReadLine();
                    question.optionA = reader.ReadLine();
                    question.optionB = reader.ReadLine();
                    question.optionC = reader.ReadLine();
                    question.optionD = reader.ReadLine();
                    temporaryList.Add(question);
                }
                reader.Close();

                foreach (var question in temporaryList)
                {

                    Console.WriteLine(question.id + ") Category: " + question.category + "\n \n" + question.questionBody + "\n\n" + " A) " + question.optionA
                        + " B) " + question.optionB + " C) " + question.optionC + " D) " + question.optionD + "\n");

                }

                
                Console.WriteLine("Question body");
                string aQuestionBody = Console.ReadLine();
                Console.WriteLine("Enter the correct answer: ");
                string aCorrectAnswer = Console.ReadLine();
                Console.WriteLine("Enter the option A: ");
                string aOptionA = Console.ReadLine();
                Console.WriteLine("Enter the option B: ");
                string aOptionB = Console.ReadLine();
                Console.WriteLine("Enter the option C: ");
                string aOptionC = Console.ReadLine();
                Console.WriteLine("Enter the option D: ");
                string aOptionD = Console.ReadLine();

                TextWriter writer = new StreamWriter("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Hard.txt",true);
                writer.WriteLine(aCategoryType);
                writer.WriteLine(aQuestionBody);
                writer.WriteLine(aCorrectAnswer);
                writer.WriteLine(aOptionA);
                writer.WriteLine(aOptionB);
                writer.WriteLine(aOptionC);
                writer.WriteLine(aOptionD);

                writer.Close();

                Console.WriteLine("Question is added ");
                getMenu();
            }
        }

        public void removeQuestion()
        {
            getAllQuestions();
            Console.WriteLine("Enter the question category : ");
            string questionCategory = Console.ReadLine();
            Console.WriteLine("Enter the question Id : ");
            int questionId = int.Parse(Console.ReadLine());

            /*
                1- ) foreach ile questionların uzeronden geç ve category id uyanı bul foreach içinde if kontrolu
                2-) Daha sonra buldugunda bu questionı sil
                3-) o foreach bitince ikinci foreach içinde yine questionlar içinde dolaş
                4-) sonraki foreache girmeden önce seçilen category de ki soruları sil
                5-) yeni bir foreach ile ve içinde if kontrolu ile yeni soru listinin içinde ki o kategoriye uygun soruları ekle
             */

            foreach (var removeQuestion in questionStore)
            {
                if (removeQuestion.category.Equals(questionCategory.ToLower()) && removeQuestion.id == questionId)
                {
                    Console.Write("quetion removed");
                    questionStore.Remove(removeQuestion);
                }
            }

            if (questionCategory.Equals("easy"))
            {
                Console.WriteLine("first if");
                File.WriteAllText("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Easy.txt",string.Empty);
                TextWriter writer = new StreamWriter("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/Easy.txt", true);
                foreach (var question in questionStore)
                {
                    if (question.category.Equals("easy"))
                    {
                        Console.WriteLine("question aded");
                        writer.WriteLine(question.category);
                        writer.WriteLine(question.questionBody);
                        writer.WriteLine(question.correctAnswer);
                        writer.WriteLine(question.optionA);
                        writer.WriteLine(question.optionB);
                        writer.WriteLine(question.optionC);
                        writer.WriteLine(question.optionD);
                    }
                }
                writer.Close();
            }else
            {
                Console.WriteLine("başka ne mk ");
            }
        }
    }
}
