using DevTeams.Data;
using DevTeams.Data.ENUMs;
using DevTeamsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_UI
{
    public class Program_UI
    {
        //we will reference our repos here...
        private readonly DeveloperRepo _devRepo = new DeveloperRepo();
        private readonly DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            Seed();
            RunApp();
        }

        

        private void RunApp()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to komodoDevTeams\n" +
                              "1. Enlist A Developer\n" +
                              "2. View All Developers\n" +
                              "3. View Developer by Id\n" +
                              "4. Update Existing Developer\n" +
                              "5. Delete Existing Developer\n" +
                              "-----------Team Menu--------\n" +
                              "6. Create A DevTeam\n" +
                              "7. View All DevTeams\n" +
                              "8. View DevTeam By Id\n" +
                              "9. Update Existing DevTeam\n" +
                              "10. Delete Existing DevTeam\n" +
                              "20. Get Developers With Pluralsight\n" +
                              "25. Close App\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        EnlistAnExistingDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperByID();
                        break;
                    case "4":
                       UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                       CreateANewDevTeam();
                        break;
                    case "7":
                        ViewAllDevTeams();
                        break;
                    case "8":
                        ViewDevTeamById();
                        break;
                    case "9":
                        UpdateExistingDevTeam();
                        break;
                    case "10":
                        DeleteExistingDevTeam();
                        break;
                    case "20":
                        GetDevlopersWithPluralsight();
                        break;
                    case "25":
                        isRunning = false;
                        Console.WriteLine("Thank you for using DevTeams,....");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private void GetDevlopersWithPluralsight()
        {
            Console.Clear();

            foreach (var dev in _devRepo.GetDevsWithPluralsight())
            {
                ShowDevDetails(dev);
            }

            Console.ReadKey();
        }

        private void DeleteExistingDevTeam()
        {
            throw new NotImplementedException();
        }

        private void UpdateExistingDevTeam()
        {
            throw new NotImplementedException();
        }

        private void ViewDevTeamById()
        {
            throw new NotImplementedException();
        }

        private void ViewAllDevTeams()
        {
            Console.Clear();

            foreach (var team in _devTeamRepo.GetDevTeams())
            {
                Console.WriteLine($"TeamId: {team.ID}\n" +
                    $"TeamName: {team.TeamName}" +
                    $"TeamDepartment: {team.TeamDepartment}\n");
                foreach (var dev in team.Developers)
                {
                    ShowDevDetails(dev);
                }
            }

            Console.ReadKey();
        }

        private void CreateANewDevTeam()
        {
            Console.Clear();
            bool hasEnlistedAllMembers = false;

            GenerateMenuTitle("Create Dev Team");
            DevTeam devTeam = new DevTeam();

            AskQuestion("Please input a team name");
            string userinputTeamName = Console.ReadLine();
            devTeam.TeamName = userinputTeamName;

            AskQuestion("Select Team Department\n" +
                        "1. SoftwareDevs\n" +
                        "2. Marketing\n" +
                        "3. GruntWorkers\n");

            int userInputTeamDepartments = int.Parse(Console.ReadLine());
            TeamDepartments uITDConversion = (TeamDepartments)userInputTeamDepartments;
            devTeam.TeamDepartment = uITDConversion;


            //this is where we add Devs to the team
            while (hasEnlistedAllMembers== false)
            {
                AskQuestion("Do You have any team members?(y/n)");

                string userInputHaveTeamMembers = Console.ReadLine().ToLower();

                if (userInputHaveTeamMembers =="y")
                {
                    Console.Clear();
                    AskQuestion("Who do you want on your team?");
                    ShowDevs();

                    int userInputSelection = int.Parse(Console.ReadLine());
                    Developer selectedDeveloper = _devRepo.GetDeveloperById(userInputSelection);
                    devTeam.Developers.Add(selectedDeveloper);

                }
                else if (userInputHaveTeamMembers == "n")
                {
                    hasEnlistedAllMembers = true;
                    Console.WriteLine($"Members Added: {devTeam.Developers.Count}");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid Opperation");
                    Console.ReadKey();
                }

            }

            _devTeamRepo.AddTeamToDatabase(devTeam);

            Console.ReadKey();
        }

        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            GenerateMenuTitle("Delete Dev");

            AskQuestion("Please input a Dev ID for DELETE");
            int usInputForDelete = int.Parse(Console.ReadLine());

            bool isSuccessful = _devRepo.DeleteDev(usInputForDelete);

            if (isSuccessful)
            {

                Console.WriteLine($"Dev with ID: {usInputForDelete} was Deleted.");
            }
            else
            {
                Console.WriteLine($"Dev with ID: {usInputForDelete} DOES NOT EXIST.");

            }

            Console.ReadKey();
        }

        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            GenerateMenuTitle("Update Dev");

            AskQuestion("Please input a Dev ID for UPDATE");
            int usInputForUpdate = int.Parse(Console.ReadLine());

            Developer newDevInfo = new Developer();

            AskQuestion("Please input Dev First Name");
            string userInputFirstName = Console.ReadLine();
            newDevInfo.FirstName = userInputFirstName;

            AskQuestion("Please input Dev First Name");
            string userInputLastName = Console.ReadLine();
            newDevInfo.LastName = userInputLastName;

            AskQuestion("Does Dev have Pluralsight (y/n)?");
            string userInputPs = Console.ReadLine().ToLower();

            //use if statement to get answer....
            if (userInputPs == "y")
            {
                newDevInfo.HasPluralsight = true;
            }
            else
            {
                newDevInfo.HasPluralsight = false;
            }

            bool isSuccessful = _devRepo.UpdateDev(usInputForUpdate, newDevInfo);

            if (isSuccessful)
            {
                Console.WriteLine("Dev Updated");
            }
            else
            {
                Console.WriteLine("Dev Update Failed");
            }

            Console.ReadKey();
        }

        private void ViewAllDevelopers()
        {
            Console.Clear();
            GenerateMenuTitle("View All Devs");
            ShowDevs();
           
            Console.ReadKey();
        }

        private void ShowDevs()
        {
            foreach (var dev in _devRepo.GetDevelopers())
            {
                ShowDevDetails(dev);
            }

        }

        private void ViewDeveloperByID()
        {
            Console.Clear();
            ShowDevs();
            Console.WriteLine("----------------------------");
            GenerateMenuTitle("Get Dev by ID");

            AskQuestion("Please Input Dev Id");
            int usInputDevId = int.Parse(Console.ReadLine());


            Developer dev = _devRepo.GetDeveloperById(usInputDevId);

            Console.Clear();
            ShowDevDetails(dev);

            Console.ReadKey();
        }

        //helper method to get DevDetails
        private void ShowDevDetails(Developer dev)
        {
            Console.WriteLine($"DevID: {dev.ID}\n" +
                   $"DevName: {dev.FullName}\n" +
                   $"DevHasPluralsight: {dev.HasPluralsight}\n" +
                   $"------------------------------------------\n");
        }

        private void EnlistAnExistingDeveloper()
        {
            Console.Clear();
            GenerateMenuTitle("Enlist A Dev");
            //we have to create a developer to assign values to 
            //via questions.
            Developer developer = new Developer();

            AskQuestion("Please input Dev First Name");
            string userInputFirstName = Console.ReadLine();
            developer.FirstName = userInputFirstName;

            AskQuestion("Please input Dev First Name");
            string userInputLastName = Console.ReadLine();
            developer.LastName = userInputLastName;

            AskQuestion("Does Dev have Pluralsight (y/n)?");
            string userInputPs = Console.ReadLine().ToLower();

            //use if statement to get answer....
            if (userInputPs=="y")
            {
                developer.HasPluralsight = true;
            }
            else
            {
                developer.HasPluralsight = false;
            }

            //we need to add the dev to the dataBase....
           bool isSuccessful= _devRepo.AddDeveloperToDatabase(developer);

            if (isSuccessful)
            {
                Console.WriteLine("Dev Created");
            }
            else
            {
                Console.WriteLine("Dev creation failed.");
            }

            Console.ReadKey();
        }


        private void AskQuestion(string question)
        {
            Console.WriteLine(question);
        }

        private void GenerateMenuTitle(string title)
        {
            Console.WriteLine($"----{title}----\n");
        }


        private void Seed()
        {
            Developer devA = new Developer("Bill","o' Riley",false);
            Developer devB = new Developer("Ted","Theodore logan",true);
            Developer devC = new Developer("James","Brown",false);
            Developer devD = new Developer("Ricky","Smiley",false);
            Developer devE = new Developer("Bernie","Mac",true);

            _devRepo.AddDeveloperToDatabase(devA);
            _devRepo.AddDeveloperToDatabase(devB);
            _devRepo.AddDeveloperToDatabase(devC);
            _devRepo.AddDeveloperToDatabase(devD);
            _devRepo.AddDeveloperToDatabase(devE);

        }
    }
}
