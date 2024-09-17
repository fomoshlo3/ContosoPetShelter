// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.0m;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "€ 85,00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "€ 49,99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "€ 40,00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "€ 45,00";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    ourAnimals[i, 6] = "Suggested Donation: " + suggestedDonation;
}

// display the top-level menu options
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }



    //Console.WriteLine($"You selected menu option {menuSelection}.");
    //Console.WriteLine("Press the Enter key to continue");

    //// pause code execution
    //readResult = Console.ReadLine();

    // provide functionality of menu

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();

                    for (int j = 0; j < 7; j++)
                        Console.WriteLine(ourAnimals[i, j]);
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;
        case "2":
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            bool validEntry = false;

            do
            {
                Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    animalSpecies = readResult.ToLower();
                    if (animalSpecies != "dog" && animalSpecies != "cat")
                    {
                        validEntry = false;
                    }
                    else
                    {
                        validEntry = true;
                    }

                    animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                    // get the pet's age. can be ? at initial entry
                    do
                    {
                        int petAge;
                        Console.WriteLine("Enter the pet's age or ? if unknown");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            if (animalAge != "?")
                            {
                                validEntry = int.TryParse(animalAge, out petAge);
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (!validEntry);

                    // gets a description of the pet's physical appearance/ condition - animalPhysicaldescription can be blank.
                    do
                    {
                        Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult.ToLower();

                            if (animalPhysicalDescription == string.Empty)
                            {
                                animalPhysicalDescription = "tbd";
                            }
                        }

                    } while (animalPhysicalDescription == string.Empty);

                    //gets a description of the pet's personality - can be blank initially.
                    do
                    {
                        Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, energy level)");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult.ToLower();
                            if (animalPersonalityDescription == string.Empty)
                                animalPersonalityDescription = "tbd";
                        }

                    } while (animalPersonalityDescription == string.Empty);

                    // get the pet's nickname. animalNickname can be blank.
                    do
                    {
                        Console.WriteLine("Enter a nickname for the pet");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            animalNickname = readResult.ToLower();
                            if (animalNickname == string.Empty)
                                animalNickname = "tbd";
                        }
                    } while (animalNickname == string.Empty);

                    // get the pet's suggested Donation, defaults to € 45,00
                    do
                    {
                        Console.WriteLine("Enter the pet's suggested donation:");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            if (!decimal.TryParse(readResult, out decimalDonation))
                                decimalDonation = 45.00m;
                            suggestedDonation = decimalDonation.ToString("{0:C2}");
                        }
                    } while (suggestedDonation == string.Empty);

                    ourAnimals[petCount, 0] = "ID #: " + animalID;
                    ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                    ourAnimals[petCount, 2] = "Age: " + animalAge;
                    ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                    ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                    ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                    ourAnimals[petCount, 6] = "Suggested Donation: " + suggestedDonation;
                }
            } while (!validEntry);

            while (anotherPet == "y" && petCount < maxPets)
            {
                petCount = petCount + 1;

                if (petCount < maxPets)
                {
                    Console.Write("Do you want to enter info for another pet? (y/n)");

                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                Console.ReadLine();
            }
            break;

        // checks age and physical Description of each entry for completeness
        case "3":
            // ensuring petCount is zero
            petCount = 0;

            // for loop getting only ID'd pets
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }

            // for loop iterating over age and phys description property of id'd pets
            for (int i = 0; i < petCount; i++)
            {
                int petAge;

                // Cutting off trailing 'Age : ' part.
                animalAge = ourAnimals[i, 2].Remove(0, 5);

                // Cutting off trailing 'Physical description : ' part.
                animalPhysicalDescription = ourAnimals[i, 4].Remove(0, 22);

                // validating pet's age
                while (!int.TryParse(animalAge, out petAge))
                {
                    Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalAge = readResult.ToLower().Trim();

                }

                // validating pet's physical description
                while (animalPhysicalDescription == string.Empty || animalPhysicalDescription == null)
                {
                    Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                        animalPhysicalDescription = readResult.ToLower().Trim();

                }

                // saving to array
                ourAnimals[i, 2] = "Age : " + animalAge;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            }

            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;
        case "4":
            // ensuring petCount is zero
            petCount = 0;

            // for loop getting only ID'd pets
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }

            for (int i = 0; i < petCount; i++)
            {
                animalNickname = ourAnimals[i, 3].Remove(0, 10);
                animalPersonalityDescription = ourAnimals[i, 5].Remove(0, 13);

                while (animalNickname == null || animalNickname == string.Empty)
                {
                    Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        // Trimming off any whitespace
                        animalNickname = readResult.ToLower().Trim(' ');
                }

                while (animalPersonalityDescription == null || animalPersonalityDescription == string.Empty)
                {
                    Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]}");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalPersonalityDescription = readResult.ToLower().Trim(' ');
                }

                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
            }

            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;
        case "5":
            Console.WriteLine("<Edit age feature>");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;
        case "6":
            Console.WriteLine("<Edit personality description>");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;
        case "7":
            Console.WriteLine("<Display cats with specified characteristics>");
            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;
        case "8":
            //TODO: #1 Display all dogs with multiple search characteristics
            string dogCharacteristic = string.Empty;
            string[] dogCharacteristics = [];

            while (dogCharacteristic == string.Empty)
            {
                // #2 have user enter multiple comma separated characteristics to search for
                Console.WriteLine("Enter desired characteristics to search for separated by commas");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                    // check for multiple characteristics searched
                    if (dogCharacteristic.Contains(','))
                    {
                        // overload trimmed characteristics into array for later use
                        dogCharacteristics = dogCharacteristic.Split(",", StringSplitOptions.TrimEntries);

                        // sort alphabetically
                        Array.Sort(dogCharacteristics);
                    }
                    else
                        dogCharacteristics = [dogCharacteristic];
                }
            }

            // #4 update to "rotating" animation with countdown
            string[] searchingIcons = { "| ", "/ ", "--", "\\ ", "* " };
            //string[] searchingCountdown = { "2..", "1. ", "0  " };
            string dogDescription = string.Empty;
            bool noMatchesDog = true;

            for (int i = 0; i < maxPets; i++)
            {
                // ensure only valid entries are searched
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    // search combined description and report results
                    if (ourAnimals[i, 1].Contains("dog"))
                    {
                        // combine description without preceeding 'header'
                        dogDescription = ourAnimals[i, 4].Substring(ourAnimals[i, 4].IndexOf(' ')) + ", " +
                                         ourAnimals[i, 5].Substring(ourAnimals[i, 5].IndexOf(' '));

                        foreach (string characteristic in dogCharacteristics)
                        {
                            for (int j = 2; j > -1; j--)
                            {
                                // #5 update "searching" message to show countdown 
                                foreach (string icon in searchingIcons)
                                {
                                    Console.Write($"\rsearching...{characteristic} {icon}{j}");
                                    Thread.Sleep(100);
                                }
                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }

                            // #3a iterate submitted characteristic terms and search description for each term

                            if (dogDescription.Contains(characteristic))
                            {
                                noMatchesDog = false;

                                // #3b update message to reflect term 
                                // #3c set a flag "this dog" is a match
                                Console.WriteLine($"\rOur dog {ourAnimals[i, 3].Substring(9)} matches your search for {characteristic}!");
                            }
                        }

                        // #3d if "this dog" is match write match message + dog description
                        if (!noMatchesDog)
                        {
                            // concatenating output message
                            string output = String.Format("{0} ({1})\n\r{2}\n\r{3}", ourAnimals[i, 3], ourAnimals[i, 0], ourAnimals[i, 4], ourAnimals[i, 5]);
                            Console.WriteLine(output);
                        }
                    }
                }
            }

            // 4. "no dogs matched" Output
            if (noMatchesDog)
                Console.WriteLine("None of our dogs are a match for: " + dogCharacteristic);

            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
            break;
        default:
            break;
    }
} while (menuSelection != "exit");
