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
                StreamReader reader = new StreamReader("/Users/kadirkutluhanalev/Desktop/Who_Wants_ToBe_A_Millioner/"+categories[k]+".txt");
                
                while (reader.EndOfStream == false)
                {


                    QuestionModel newQuestion = new QuestionModel();
                    newQuestion.category = reader.ReadLine();
                    newQuestion.id = reader.ReadLine();
                    newQuestion.questionBody = reader.ReadLine();
                    newQuestion.correctAnswer = reader.ReadLine();
                    newQuestion.optionA = reader.ReadLine();
                    newQuestion.optionB = reader.ReadLine();
                    newQuestion.optionC = reader.ReadLine();
                    newQuestion.optionD = reader.ReadLine();
                    
                    questionStore.Add(newQuestion);
                    
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
            string id = Console.ReadLine();
            Console.WriteLine("Yeni soruyu giriniz: ");
            string newQuestionBody = Console.ReadLine();
            editQuestion(category, id, newQuestionBody);
           
        }



        public void editQuestion(string category,string id, string newQuestionBody)
        {
            if(category.ToLower() == "easy")
            {

                foreach (var question in questionStore)
                {
                    if (question.category.Equals(category) && question.id.Equals(id))
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
                        tw.WriteLine(question.id);
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
                    if (question.category.Equals(category) && question.id.Equals(id))
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
                        tw.WriteLine(question.id);
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
                    if (question.category.Equals(category) && question.id.Equals(id))
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
                        tw.WriteLine(question.id);
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

        }

        public void removeQuestion()
        {

        }
    }
}
