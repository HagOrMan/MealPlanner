using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace WeeklyMealPlannerXMLTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //for if takeout is chosen
        private static bool takeout = false;

        static XmlDocument doc = new XmlDocument();
        static XmlNodeList elemListName = null;
        static XmlNodeList elemListTime = null;
        static XmlNodeList elemListSide = null;
        static XmlNodeList elemListBbq = null;

        //random number generator
        private static readonly Random random = new Random();

        //for the meal choice index in the array that is chosen. up to 4 meals, therefore a size 4 array
        private static int[] meals = new int[] { -1, -1, -1, -1 };

        public MainWindow()
        {
            InitializeComponent();

            //Loads the XML File.
            doc.PreserveWhitespace = true;
            try { doc.Load("WeeklyMeals.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                doc.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<Weekly_Meals> \n" +
                "  <Meal> \n" +
                "    <name>Fajitas</name> \n" +
                "    <time>40</time> \n" +
                "  </Meal> \n" +
                "  <Meal> \n" +
                "    <name>If you see this there was an error</name> \n" +
                "    <time>50</time> \n" +
                "  </Meal> \n" +
                "</Weekly_Meals>");
            }

            elemListName = doc.GetElementsByTagName("name");
            elemListTime = doc.GetElementsByTagName("time");
            elemListSide = doc.GetElementsByTagName("side");
            elemListBbq = doc.GetElementsByTagName("bbq");

        }

        //Shows the user the meals. Activated when the user presses the main button for meals.
        private void ChoiceButton_Click(object sender, RoutedEventArgs e)
        {

            //Resets the meals thing every time so it doesn't think that it's already chosen that meal on another run through
            meals[0] = -1;
            meals[1] = -1;
            meals[2] = -1;

            //Checks if they want takeout or not
            if (CheckBox.IsChecked == true)
            {
                takeout = true;
            }
            else
            {
                takeout = false;
            }

            //Resets the meals text everytime this method is done
            Meals.Text = "";

            //Array of all days of the week starting from the day the first meal would be made. Just for saying _ meal will be made this day and next day you'll eat previous day's meal
            String[] daysOfWeek = new string[] { "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            //Sees how many meal options there are in the array.
            int mealChoices = elemListName.Count;

            //Day of the week, the choice being made, and the amount of meals chosen for the week
            int weekDay = 0;
            int choice = 0;
            int mealsChosen = 0;

            int indexForMealsArray = 0;

            //Checks if they want takeout or not
            if (takeout == false)
            {

                //Monday and Tuesday are always Sunday meals
                Meals.Text = Meals.Text + "Monday: Sunday repeat" + "\n" + "Tuesday: Sunday repeat" + "\n";

                //Continues until 3 meals have been made that week
                while (mealsChosen < 3)
                {
                    do
                    {
                        //Randomizes the meal choice
                        choice = random.Next(mealChoices);

                        //Makes sure that if it's a week day, the meal takes less than 45 minutes to make
                        if (weekDay == 0)
                        {
                            int timeToMake = Int32.Parse(elemListTime[choice].InnerText);
                            while (timeToMake > 45)
                            {
                                choice = random.Next(mealChoices);
                                timeToMake = Int32.Parse(elemListTime[choice].InnerText);
                            }
                        }

                        //Ensures the meal chosen hasn't already been chosen
                    } while (choice == meals[0] || choice == meals[1] || choice == meals[2] || choice == meals[3]);

                    if (weekDay == 4)
                    {
                        Meals.Text = Meals.Text + daysOfWeek[weekDay] + ": " + elemListName[choice].InnerText + ". " + elemListTime[choice].InnerText + " min" + "\n";
                        weekDay = weekDay + 2;
                    }
                    else
                    {
                        Meals.Text = Meals.Text + daysOfWeek[weekDay] + ": " + elemListName[choice].InnerText + ". " + elemListTime[choice].InnerText + " min" + "\n" + daysOfWeek[weekDay + 1] + ": " + daysOfWeek[weekDay] + " repeat" + "\n";
                        weekDay = weekDay + 2;
                    }

                    //Sets an index in the meals array to the index chosen of the meal.
                    meals[indexForMealsArray] = choice;
                    indexForMealsArray++;

                    mealsChosen++;

                }
            }
            else
            {
                weekDay = 2;
                Meals.Text = Meals.Text + "Monday: Sunday repeat" + "\n" + "Tuesday: Sunday repeat" + "\n" + "Wednesday: Takeout" + "\n" + "Thursday: Takeout repeat" + "\n";
                while (mealsChosen < 2)
                {
                    do
                    {
                        choice = random.Next(mealChoices);
                    } while (choice == meals[0] || choice == meals[1] || choice == meals[2] || choice == meals[3]);

                    if (weekDay == 4)
                    {
                        Meals.Text = Meals.Text + daysOfWeek[weekDay] + ": " + elemListName[choice].InnerText + ". " + elemListTime[choice].InnerText + " min" + "\n";
                        weekDay = weekDay + 2;
                    }
                    else
                    {
                        Meals.Text = Meals.Text + daysOfWeek[weekDay] + ": " + elemListName[choice].InnerText + ". " + elemListTime[choice].InnerText + " min" + "\n" + daysOfWeek[weekDay + 1] + ": " + daysOfWeek[weekDay] + " repeat" + "\n";
                        weekDay = weekDay + 2;
                    }

                    meals[indexForMealsArray] = choice;
                    indexForMealsArray++;

                    mealsChosen++;
                }

            }

        }

        //Accidental method.
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        //Gives the user an extra short meal when the user wants one.
        private void ExtraShortMeal_Click(object sender, RoutedEventArgs e)
        {

            //Variable for the amount of choices that can be chosen.
            int mealChoices = elemListName.Count;
            int choice = 0;

            int timeToMake = 0;

            //Makes sure choice hasn't been chosen in the main one
            do
            {
                choice = random.Next(mealChoices);

                timeToMake = Int32.Parse(elemListTime[choice].InnerText);
                while (timeToMake > 45)
                {
                    choice = random.Next(mealChoices);
                    timeToMake = Int32.Parse(elemListTime[choice].InnerText);
                }

            } while (choice == meals[0] || choice == meals[1] || choice == meals[2] || choice == meals[3]);

            meals[3] = choice;

            ShortMealText.Text = elemListName[choice].InnerText + ". " + elemListTime[choice].InnerText + " min";

        }

        //Adds a side to the xml file and saves it.
        public static void AddSide(string strName)
        {

            //Creates a root node.
            XmlNode root = doc.DocumentElement;

            //Create a new node for name and time.
            XmlElement side = doc.CreateElement("side");
            side.InnerText = strName;

            //Creates the meal node and adds the name to it.
            XmlElement meal = doc.CreateElement("Meal");
            meal.AppendChild(side);

            //Add the side node to the document.
            root.AppendChild(meal);

            //Saves the document.
            saveDoc();

            //Adds the newest addition to the list by resetting it.
            elemListSide = doc.GetElementsByTagName("side");

        }

        //Adds a BBQ meal to the xml file and saves it.
        public static void AddBbq(string strName)
        {

            //Creates a root node.
            XmlNode root = doc.DocumentElement;

            //Create a new node for name and time.
            XmlElement bbq = doc.CreateElement("bbq");
            bbq.InnerText = strName;

            //Creates the meal node and adds the name to it.
            XmlElement meal = doc.CreateElement("Meal");
            meal.AppendChild(bbq);

            //Add the side node to the document.
            root.AppendChild(meal);

            //Saves the document.
            saveDoc();

            //Adds the newest addition to the list by resetting it.
            elemListBbq = doc.GetElementsByTagName("bbq");

        }

        //Adds a meal to the xml file and saves it.
        public static void AddMeal(string strName, string strTime)
        {

            //Creates a root node.
            XmlNode root = doc.DocumentElement;

            //Create a new node for name and time.
            XmlElement name = doc.CreateElement("name");
            name.InnerText = strName;
            XmlElement time = doc.CreateElement("time");
            time.InnerText = strTime;

            //Creates the meal node and adds the name and time to it.
            XmlElement meal = doc.CreateElement("Meal");
            meal.AppendChild(name);
            meal.AppendChild(time);

            //Add the meal node to the document.
            root.AppendChild(meal);

            //Saves the document.
            saveDoc();

            //Adds the newest addition to the list by resetting it.
            elemListName = doc.GetElementsByTagName("name");
            elemListTime = doc.GetElementsByTagName("time");

        }

        //Saves the document.
        private static void saveDoc()
        {
            doc.PreserveWhitespace = true;
            doc.Save("WeeklyMeals.xml");
        }

        //Shows all meals and times needed to make them in a text box.
        private void ShowXmlBtn_Click(object sender, RoutedEventArgs e)
        {

            AllMealsTxtBox.Text = "";

            for (int i = 0; i < elemListName.Count; i++)
            {
                AllMealsTxtBox.Text += (i + 1) + " | Meal: " + elemListName[i].InnerXml + "\n     Time: " + elemListTime[i].InnerXml + "\n";
            }

        }

        //Accident.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        //Opens the form for the user to add a meal.
        private void AddMealBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMealForm mealForm = new AddMealForm();
            mealForm.Show();
        }

        //Accident
        private void AllMealsTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Deletes the specified meal from the list.
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //Tries the parse the input and displays an error if they didn't enter a number.
            int deleteIndex = 0;
            try
            {
                deleteIndex = Int32.Parse(DeleteTxtBox.Text);
            }
            catch (Exception)
            {
                DeleteTxtBox.Text = "Not a valid answer";
                return;
            }

            //Says there's an error if they input a number that doesn't exist.
            if (deleteIndex > elemListName.Count || deleteIndex <= 0)
            {
                DeleteTxtBox.Text = "This meal number does not exist";
                return;
            }

            //Creates a temp doc with the same beginning as the old one, and same root node.
            XmlDocument tempDoc = new XmlDocument();
            tempDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + "\n<Weekly_Meals></Weekly_Meals>");

            //Creates a root node.
            XmlNode root = tempDoc.DocumentElement;

            //Goes through each element currently in the doc and adds them all the a new doc except for the one the user wants deleted.
            for (int i = 0; i < elemListName.Count; i++)
            {

                //Ensures that the meal the user wants deleted is not added to the new doc.
                if (i + 1 != deleteIndex)
                {

                    string strTime = elemListTime[i].InnerText;
                    string strName = elemListName[i].InnerText;

                    //Create a new node for name and time.
                    XmlElement name = tempDoc.CreateElement("name");
                    name.InnerText = strName;
                    XmlElement time = tempDoc.CreateElement("time");
                    time.InnerText = strTime;

                    //Creates the meal node and adds the name and time to it.
                    XmlElement meal = tempDoc.CreateElement("Meal");
                    meal.AppendChild(name);
                    meal.AppendChild(time);

                    //Add the meal node to the document.
                    root.AppendChild(meal);
                    
                }
            }

            //Goes through all side dishes and adds them.
            for (int i = 0; i < elemListSide.Count; i++)
            {

                string strSide = elemListSide[i].InnerText;

                //Create a new node for the side.
                XmlElement side = tempDoc.CreateElement("side");
                side.InnerText = strSide;

                //Creates the meal node and adds the side to it.
                XmlElement meal = tempDoc.CreateElement("Meal");
                meal.AppendChild(side);

                //Add the meal node to the document.
                root.AppendChild(meal);

            }

            //Goes through all BBQ dishes and adds them.
            for (int i = 0; i < elemListBbq.Count; i++)
            {

                string strBbq = elemListBbq[i].InnerText;

                //Create a new node for the bbq.
                XmlElement bbq = tempDoc.CreateElement("bbq");
                bbq.InnerText = strBbq;

                //Creates the meal node and adds the bbq to it.
                XmlElement meal = tempDoc.CreateElement("Meal");
                meal.AppendChild(bbq);

                //Add the meal node to the document.
                root.AppendChild(meal);

            }

            //Once everything has been added, makes the old doc the new one.
            doc = tempDoc;

            //Saves the document.
            saveDoc();

            //Creates an updated version of the elements without the deleted one in the list by resetting it.
            elemListName = doc.GetElementsByTagName("name");
            elemListTime = doc.GetElementsByTagName("time");

            //Resets the text box text.
            if (DeleteChkBox.IsChecked == true)
            {
                DeleteTxtBox.Text = "";
            }
            else
            {
                DeleteTxtBox.Text = "Enter # here";
            }

        }

        //Clears the text box showing all meals.
        private void ClearMealBtn_Click(object sender, RoutedEventArgs e)
        {
            AllMealsTxtBox.Text = "";
        }

        //Adds a side to the meal planner by opening the side window.
        private void AddSideBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSideForm sideForm = new AddSideForm();
            sideForm.Show();
        }

        //Updates the list of side items.
        private void UpdateSideBtn_Click(object sender, RoutedEventArgs e)
        {
            SideTxtBox.Text = "";

            for (int i = 0; i < elemListSide.Count; i++)
            {
                SideTxtBox.Text += (i + 1) + " |  " + elemListSide[i].InnerXml + "\n";
            }
        }

        //Adds a BBQ meal to the meal planner by opening the bbq window.
        private void AddBbqBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBBQForm sideForm = new AddBBQForm();
            sideForm.Show();
        }

        //Updates the list of BBQ items.
        private void UpdateBbqBtn_Click(object sender, RoutedEventArgs e)
        {
            BbqTxtBox.Text = "";

            for (int i = 0; i < elemListBbq.Count; i++)
            {
                BbqTxtBox.Text += (i + 1) + " |  " + elemListBbq[i].InnerXml + "\n";
            }
        }

        //Deletes the specified side from the list.
        private void DeleteSideBtn_Click(object sender, RoutedEventArgs e)
        {
            //Tries the parse the input and displays an error if they didn't enter a number.
            int deleteIndex = 0;
            try
            {
                deleteIndex = Int32.Parse(DeleteTxtBox.Text);
            }
            catch (Exception)
            {
                DeleteTxtBox.Text = "Not a valid answer";
                return;
            }

            //Says there's an error if they input a number that doesn't exist.
            if (deleteIndex > elemListSide.Count || deleteIndex <= 0)
            {
                DeleteTxtBox.Text = "This side number does not exist";
                return;
            }

            //Creates a temp doc with the same beginning as the old one, and same root node.
            XmlDocument tempDoc = new XmlDocument();
            tempDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + "\n<Weekly_Meals></Weekly_Meals>");

            //Creates a root node.
            XmlNode root = tempDoc.DocumentElement;

            //Adds each meal currently in the doc.
            for (int i = 0; i < elemListName.Count; i++)
            {

                string strTime = elemListTime[i].InnerText;
                string strName = elemListName[i].InnerText;

                //Create a new node for name and time.
                XmlElement name = tempDoc.CreateElement("name");
                name.InnerText = strName;
                XmlElement time = tempDoc.CreateElement("time");
                time.InnerText = strTime;

                //Creates the meal node and adds the name and time to it.
                XmlElement meal = tempDoc.CreateElement("Meal");
                meal.AppendChild(name);
                meal.AppendChild(time);

                //Add the meal node to the document.
                root.AppendChild(meal);

            }

            //Goes through all side dishes and adds them, except for the one that the user wants deleted.
            for (int i = 0; i < elemListSide.Count; i++)
            {

                //Ensures that the side the user wants deleted is not added to the new doc.
                if (i + 1 != deleteIndex)
                {

                    string strSide = elemListSide[i].InnerText;

                    //Create a new node for the side.
                    XmlElement side = tempDoc.CreateElement("side");
                    side.InnerText = strSide;

                    //Creates the meal node and adds the side to it.
                    XmlElement meal = tempDoc.CreateElement("Meal");
                    meal.AppendChild(side);

                    //Add the meal node to the document.
                    root.AppendChild(meal);

                }

            }

            //Goes through all BBQ dishes and adds them.
            for (int i = 0; i < elemListBbq.Count; i++)
            {

                string strBbq = elemListBbq[i].InnerText;

                //Create a new node for the bbq.
                XmlElement bbq = tempDoc.CreateElement("bbq");
                bbq.InnerText = strBbq;

                //Creates the meal node and adds the bbq to it.
                XmlElement meal = tempDoc.CreateElement("Meal");
                meal.AppendChild(bbq);

                //Add the meal node to the document.
                root.AppendChild(meal);

            }

            //Once everything has been added, makes the old doc the new one.
            doc = tempDoc;

            //Saves the document.
            saveDoc();

            //Creates an updated version of the elements without the deleted one in the list by resetting it.
            elemListSide = doc.GetElementsByTagName("side");

            //Resets the text box text.
            if (DeleteChkBox.IsChecked == true)
            {
                DeleteTxtBox.Text = "";
            }
            else
            {
                DeleteTxtBox.Text = "Enter # here";
            }
        }

        //Deletes the specified BBQ meal from the list.
        private void DeleteBbqBtn_Click(object sender, RoutedEventArgs e)
        {

            //Tries the parse the input and displays an error if they didn't enter a number.
            int deleteIndex = 0;
            try
            {
                deleteIndex = Int32.Parse(DeleteTxtBox.Text);
            }
            catch (Exception)
            {
                DeleteTxtBox.Text = "Not a valid answer";
                return;
            }

            //Says there's an error if they input a number that doesn't exist.
            if (deleteIndex > elemListBbq.Count || deleteIndex <= 0)
            {
                DeleteTxtBox.Text = "This BBQ meal number does not exist";
                return;
            }

            //Creates a temp doc with the same beginning as the old one, and same root node.
            XmlDocument tempDoc = new XmlDocument();
            tempDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + "\n<Weekly_Meals></Weekly_Meals>");

            //Creates a root node.
            XmlNode root = tempDoc.DocumentElement;

            //Adds each meal currently in the doc.
            for (int i = 0; i < elemListName.Count; i++)
            {

                string strTime = elemListTime[i].InnerText;
                string strName = elemListName[i].InnerText;

                //Create a new node for name and time.
                XmlElement name = tempDoc.CreateElement("name");
                name.InnerText = strName;
                XmlElement time = tempDoc.CreateElement("time");
                time.InnerText = strTime;

                //Creates the meal node and adds the name and time to it.
                XmlElement meal = tempDoc.CreateElement("Meal");
                meal.AppendChild(name);
                meal.AppendChild(time);

                //Add the meal node to the document.
                root.AppendChild(meal);

            }

            //Adds each side meal to the doc.
            for (int i = 0; i < elemListSide.Count; i++)
            {

                string strSide = elemListSide[i].InnerText;

                //Create a new node for the side.
                XmlElement side = tempDoc.CreateElement("side");
                side.InnerText = strSide;

                //Creates the meal node and adds the side to it.
                XmlElement meal = tempDoc.CreateElement("Meal");
                meal.AppendChild(side);

                //Add the meal node to the document.
                root.AppendChild(meal);

            }

            //Goes through all BBQ dishes and adds them, except for the one that the user wants deleted.
            for (int i = 0; i < elemListBbq.Count; i++)
            {

                //Ensures that the BBQ meal the user wants deleted is not added to the new doc.
                if (i + 1 != deleteIndex)
                {

                    string strBbq = elemListBbq[i].InnerText;

                    //Create a new node for the bbq.
                    XmlElement bbq = tempDoc.CreateElement("bbq");
                    bbq.InnerText = strBbq;

                    //Creates the meal node and adds the bbq to it.
                    XmlElement meal = tempDoc.CreateElement("Meal");
                    meal.AppendChild(bbq);

                    //Add the meal node to the document.
                    root.AppendChild(meal);

                }

            }

            //Once everything has been added, makes the old doc the new one.
            doc = tempDoc;

            //Saves the document.
            saveDoc();

            //Creates an updated version of the elements without the deleted one in the list by resetting it.
            elemListBbq = doc.GetElementsByTagName("bbq");

            //Resets the text box text.
            if (DeleteChkBox.IsChecked == true)
            {
                DeleteTxtBox.Text = "";
            }
            else
            {
                DeleteTxtBox.Text = "Enter # here";
            }
        }

        //Saves current list in a backup file.
        private void SaveBackupBtn_Click(object sender, RoutedEventArgs e)
        {
            doc.PreserveWhitespace = true;
            doc.Save("WeeklyMealsBackup.xml");
        }

        //Imports the backup file and replaces the current doc with it.
        private void ImportBackupBtn_Click(object sender, RoutedEventArgs e)
        {
            doc.PreserveWhitespace = true;
            try { doc.Load("WeeklyMealsBackup.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                doc.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<Weekly_Meals> \n" +
                "  <Meal> \n" +
                "    <name>Fajitas</name> \n" +
                "    <time>40</time> \n" +
                "  </Meal> \n" +
                "  <Meal> \n" +
                "    <name>If you see this there was an error</name> \n" +
                "    <time>50</time> \n" +
                "  </Meal> \n" +
                "</Weekly_Meals>");
            }

            elemListName = doc.GetElementsByTagName("name");
            elemListTime = doc.GetElementsByTagName("time");
            elemListSide = doc.GetElementsByTagName("side");
            elemListBbq = doc.GetElementsByTagName("bbq");
        }
    }
}
