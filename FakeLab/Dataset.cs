﻿namespace FakeLab
{
    internal static class Dataset
    {
        internal static Dictionary<string, string[]> Data { get; } = new Dictionary<string, string[]>()
        {
            {"Names", Names},
            {"Surnames", Surnames},
            {"Addresses", Addresses}
        };

        private static string[] Names => ["James", "John", "Robert", "Michael", "William", "David", "Joseph", "Charles", "Thomas", "Daniel", "Matthew", "Anthony", "Mark", "Donald", "Steven", "Paul", "Andrew", "Joshua", "Kevin", "Brian", "George", "Timothy", "Ronald", "Edward", "Jason", "Jeffrey", "Ryan", "Gary", "Nicholas", "Eric", "Stephen", "Larry", "Justin", "Scott", "Brandon", "Benjamin", "Samuel", "Gregory", "Frank", "Alexander", "Raymond", "Patrick", "Jack", "Dennis", "Jerry", "Tyler", "Aaron", "Henry", "Douglas", "Peter", "Walter", "Adam", "Nathan", "Zachary", "Kyle", "Carl", "Arthur", "Gerald", "Roger", "Keith", "Christian", "Terry", "Sean", "Ethan", "Douglas", "Adam", "Austin", "Nathaniel", "Jack", "Bryan", "Jesse", "Carlton", "Phillip", "Warren", "Alan", "Louis", "Wayne", "Clarence", "Billy", "Johnny", "Victor", "Leroy", "Leonard", "Martin", "Francis", "Melvin", "Oscar", "Stanley", "Leon", "Maurice", "Dale", "Herman", "Roy", "Lester", "Victor", "Norman", "Ronnie", "Bobby", "Vincent", "Terry", "Todd", "Joel", "Douglas", "Eugene", "Morris", "Howard", "Francisco", "Ralph", "Charlie", "Hugh", "Craig", "Barry", "Fred", "Elliot", "Dwayne", "Bryce", "Kurt", "Troy", "Clyde", "Jimmy", "Dean", "Spencer", "Jay", "Clifford", "Dan", "Lee", "Gilbert", "Wesley", "Leo", "Fredrick", "Willard", "Emmett", "Blake", "Keith", "Jerome", "Alfred", "Willis", "Lyle", "Ruben", "Lawrence", "Bert", "Edwin", "Harrison", "Royce", "Marty", "Roscoe", "Clinton", "Marshall", "Sylvester", "Derrick", "Alvin", "Russell", "Jorge", "Darryl", "Bradley", "Calvin", "Reuben", "Wendell", "Shelby", "Blaine", "Emilio", "Luther", "Elliot", "Dale", "Sam", "Glen", "Adrian", "Alfredo", "Ansel", "Archer", "Avery", "Barrett", "Blake", "Brad", "Brayden", "Brice", "Brock", "Brooks", "Caden", "Caleb", "Chad", "Chase", "Clinton", "Colby", "Colton", "Curtis", "Damian", "Darren", "Daryl", "Dexter", "Diego", "Dustin", "Easton", "Eli", "Eliot", "Emory", "Everett", "Finley", "Gage", "Gavin", "Graham", "Grant", "Grayson", "Guy", "Harlan", "Hendrix", "Hunter", "Isaiah", "Ishmael", "Jace", "Jaden", "Jake", "Jared", "Jason", "Jayden", "Jensen", "Jesse", "Joaquin", "Joel", "Jonah", "Jordan", "Jose", "Josiah", "Julian", "Keith", "Kendall", "Kenny", "Kieran", "Kingston", "Kyle", "Landon", "Lennox", "Leo", "Liam", "Lincoln", "Louis", "Luca", "Mack", "Malcolm", "Manuel", "Marco", "Marcus", "Mario", "Markus", "Marshall", "Mason", "Mathew", "Max", "Micheal", "Miles", "Milo", "Nathaniel", "Nico", "Noah", "Oliver", "Oscar", "Owen", "Parker", "Paul", "Preston", "Quentin", "Rafael", "Reed", "Reid", "Riley", "Roberto", "Rocky", "Roland", "Ronnie", "Ruben", "Salvador", "Seth", "Shane", "Silas", "Simon", "Skyler", "Spencer", "Tanner", "Tate", "Thaddeus", "Theo", "Thomas", "Tobias", "Tucker", "Tyler", "Victor", "Vincent", "Wade", "Walker", "Warren", "Will", "Wyatt", "Xander", "Zane", "Zeke", "Abel", "Ace", "Alvin", "Aiden", "Alec", "Arlo", "Asher", "Atticus", "Bartholomew", "Baxter", "Benedict", "Blaze", "Bo", "Bram", "Bran", "Brendan", "Briggs", "Broderick", "Cale", "Callum", "Camden", "Carlton", "Cassius", "Cedric", "Chance", "Charlie", "Chester", "Clyde", "Clive", "Colin", "Corey", "Cyrus", "Dante", "Darwin", "Davis", "Dawson", "Dean", "Desmond", "Dex", "Dorian", "Douglas", "Drake", "Dwight", "Eamon", "Elijah", "Emerson", "Enzo", "Ezekiel", "Fletcher", "Francisco", "Gage", "Gareth", "Gideon", "Glen", "Graham", "Grant", "Harold", "Harris", "Hendrix", "Hugo", "Hunter", "Ike", "Irving", "Jacek", "Jalen", "Jasper", "Jax", "Jett", "Joaquin", "Joel", "Jonas", "Jovan", "Julian", "Kaiser", "Kane", "Kellen", "Ken", "Kerr", "Kieran", "King", "Knox", "Lachlan", "Lance", "Lennon", "Leo", "Lyle", "Mackenzie", "Manuel", "Marc", "Marlow", "Mason", "Maurice", "Maximus", "Merrick", "Milo", "Moe", "Montgomery", "Nash", "Nate", "Nico", "Niles", "Odin", "Omar", "Orson", "Otis", "Paul", "Percival", "Perry", "Quincy", "Reagan", "Remington", "Rex", "Rey", "Rhett", "Ronin", "Royce", "Russell", "Salvatore", "Samson", "Santino", "Saul", "Sebastian", "Seth", "Silas", "Stanley", "Sterling", "Stone", "Sylvester", "Theo", "Thorn", "Tobias", "Travis", "Trey", "Tristan", "Troy", "Tyson", "Uriah", "Vaughn", "Vernon", "Wade", "Weston", "Wilbur", "Willis", "Winston", "Wyatt", "Zachariah"];
        private static string[] Surnames => ["Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Rodriguez", "Lopez", "Wilson", "Anderson", "Thomas", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Clark", "Lewis", "Roberts", "Walker", "Young", "Allen", "King", "Scott", "Green", "Adams", "Baker", "Nelson", "Carter", "Mitchell", "Perez", "Robinson", "Gomez", "Phillips", "Evans", "Turner", "Collins", "Edwards", "Stewart", "Morris", "Ortiz", "Morgan", "Cooper", "Reed", "Cook", "Bailey", "Bell", "Murphy", "Rivera", "Howard", "Ward", "Cox", "Diaz", "Richardson", "Wood", "James", "Bennett", "Gray", "Mendoza", "Ruiz", "Foster", "Sanders", "Price", "Powell", "Long", "Ross", "Hughes", "Flores", "Wright", "King", "Stone", "Warren", "Butler", "Barnes", "Henderson", "Graham", "Kelly", "Alexander", "Russell", "Douglas", "Harper", "Simpson", "Gordon", "Shaw", "Williamson", "Tran", "Chavez", "Patel", "Simmons", "Fisher", "Stevens", "Morris", "Kim", "Jenkins", "Perry", "Powell", "Russell", "Bryant", "Grant", "Duncan", "Daniels", "Palmer", "Bowman", "Chapman", "Gregory", "Black", "Hunt", "Wagner", "Harrison", "Gilbert", "Burns", "Curtis", "Sullivan", "Franklin", "Newton", "Holland", "Bishop", "Jameson", "Kingston", "Christensen", "Hughes", "Riley", "Douglas", "Vasquez", "Hampton", "Mason", "Blake", "Farrell", "Nichols", "Curtis", "Douglas", "Lambert", "Chang", "Dawson", "Wallace", "Lynch", "Reed", "Christian", "Knight", "Sullivan", "Murray", "Page", "Bauer", "Kelley", "Cameron", "Fletcher", "Craig", "Mullins", "Curtis", "Bishop", "Chen", "Burnett", "Vargas", "Jordan", "Parker", "Kim", "Davidson", "Nicholson", "Hodge", "Harrison", "Jensen", "Wilkins", "Ashford", "Becker", "Blanchard", "Browning", "Carlson", "Carson", "Chamberlain", "Chapman", "Clarke", "Cameron", "Dalton", "Davidson", "Davenport", "Donovan", "Douglas", "Ellis", "Evans", "Farnsworth", "Fleming", "Garner", "Granger", "Hale", "Hancock", "Harrison", "Hawkins", "Hendrix", "Hodges", "Howell", "Hudson", "Ingram", "Jackson", "Jefferson", "Jensen", "Keller", "Kenner", "Kerr", "Lawson", "Leach", "Lindsey", "Lucas", "MacDonald", "Mann", "Marshall", "Mason", "Mathews", "McCabe", "McDonald", "McKinney", "Miller", "Moore", "Newton", "O'Connor", "Osborne", "Patterson", "Pearson", "Phillips", "Phelps", "Porter", "Preston", "Quinn", "Randall", "Reynolds", "Robinson", "Ross", "Rutledge", "Schmidt", "Sellers", "Shepherd", "Sims", "Sloan", "Stephens", "Stone", "Summers", "Sweeney", "Terry", "Travis", "Turner", "Vance", "Vaughn", "Wade", "Walker", "Walsh", "Watkins", "Webb", "Weber", "Wells", "West", "Wheeler", "White", "Wiley", "Wilkins", "Wright", "Wyatt", "Yates", "Abbott", "Ainsley", "Alford", "Anderson", "Archer", "Atwood", "Barton", "Beasley", "Belmont", "Bennett", "Bishop", "Blake", "Blanchard", "Boyer", "Bradley", "Brady", "Bridges", "Brock", "Brooks", "Brown", "Bryant", "Buckley", "Burke", "Byers", "Caldwell", "Carroll", "Chapman", "Charleston", "Christensen", "Clarkson", "Cleary", "Clifford", "Cunningham", "Curtis", "Dalrymple", "Darby", "David", "Decker", "Dixon", "Douglas", "Durham", "Duncan", "Edwards", "Ferguson", "Fitzgerald", "Fleming", "Fowler", "Franklin", "Freeman", "Frost", "Galloway", "Gamble", "Garfield", "Gibson", "Gilmore", "Goodwin", "Graham", "Grant", "Gregory", "Hampton", "Harmon", "Harris", "Hawthorne", "Hughes", "Irwin", "Jackson", "Jeffries", "Johnson", "Keller", "Kemp", "Lacey", "Langley", "Larkin", "Lawrence", "Lowe", "Lucas", "Manning", "Martin", "McAllister", "McCullough", "McLaughlin", "Miller", "Morris", "Newman", "Nolan", "O'Neal", "O'Riley", "Parker", "Payne", "Perry", "Porter", "Preston", "Raleigh", "Reeves", "Reynolds", "Richards", "Roberts", "Robinson", "Rowe", "Rush", "Sampson", "Sanders", "Schneider", "Shannon", "Shepard", "Sherman", "Simpson", "Spencer", "Stanton", "Stewart", "Stone", "Tanner", "Taylor", "Thompson", "Vance", "Vaughn", "Wallace", "Walton", "Watson", "Wells", "Weston", "Whitaker", "Wilson", "Winters", "Woods"];
        private static string[] Addresses => ["United States, New York, Brooklyn", "Canada, Toronto, Scarborough", "United Kingdom, London, Camden", "Australia, Sydney, Bondi", "Germany, Berlin, Kreuzberg", "France, Paris, Le Marais", "Italy, Rome, Trastevere", "Spain, Barcelona, Eixample", "Netherlands, Amsterdam, Jordaan", "Japan, Tokyo, Shibuya", "South Korea, Seoul, Gangnam", "Brazil, Sao Paulo, Vila Madalena", "Mexico, Mexico City, Coyoacan", "Russia, Moscow, Arbat", "Sweden, Stockholm, Sodermalm", "Norway, Oslo, Grunerlokka", "Finland, Helsinki, Kallio", "Belgium, Brussels, Ixelles", "Austria, Vienna, Neubau", "Denmark, Copenhagen, Vesterbro", "Portugal, Lisbon, Alfama", "Switzerland, Zurich, Altstadt", "India, Mumbai, Bandra", "China, Shanghai, Pudong", "South Africa, Cape Town, Bo Kaap", "Argentina, Buenos Aires, Palermo", "Chile, Santiago, Providencia", "Peru, Lima, Miraflores", "Colombia, Bogota, Chapinero", "Poland, Warsaw, Srodmiescie", "Greece, Athens, Plaka", "Turkey, Istanbul, Beyoglu", "Israel, Tel Aviv, Florentin", "United Arab Emirates, Dubai, Jumeirah", "Egypt, Cairo, Zamalek", "Malaysia, Kuala Lumpur, Bukit Bintang", "Singapore, Singapore, Orchard", "Thailand, Bangkok, Sukhumvit", "Vietnam, Ho Chi Minh City, District 1", "New Zealand, Auckland, Ponsonby", "Ireland, Dublin, Temple Bar", "Romania, Bucharest, Lipscani", "Hungary, Budapest, Erzsebetvaros", "Czech Republic, Prague, Vinohrady", "Poland, Krakow, Kazimierz", "Slovenia, Ljubljana, Trnovo", "Croatia, Zagreb, Donji Grad", "Serbia, Belgrade, Vracar", "Bulgaria, Sofia, Lozenets", "Ukraine, Kyiv, Podil", "Lithuania, Vilnius, Old Town", "Estonia, Tallinn, Kalamaja", "Latvia, Riga, Centrs", "Belarus, Minsk, Tsentralny", "Kazakhstan, Almaty, Medeu", "Armenia, Yerevan, Kentron", "Georgia, Tbilisi, Vake", "Kyrgyzstan, Bishkek, Oktyabrsky", "Uzbekistan, Tashkent, Mirabad", "Turkmenistan, Ashgabat, Kopetdag", "Mongolia, Ulaanbaatar, Sukhbaatar", "Tajikistan, Dushanbe, Sino", "Azerbaijan, Baku, Sabail", "Lebanon, Beirut, Achrafieh", "Jordan, Amman, Abdali", "Iraq, Baghdad, Karrada", "Syria, Damascus, Mazzeh", "Afghanistan, Kabul, Shahr e Naw", "Pakistan, Karachi, Saddar", "Sri Lanka, Colombo, Fort", "Nepal, Kathmandu, Thamel", "Bangladesh, Dhaka, Gulshan", "Norway, Bergen, Bryggen", "Finland, Tampere, Kaleva", "Sweden, Gothenburg, Hisingen", "Denmark, Aarhus, Midtbyen", "Belgium, Antwerp, Zurenborg", "Ireland, Cork, St Lukes", "Italy, Milan, Navigli", "Germany, Hamburg, Altona", "France, Marseille, Le Panier", "United States, Los Angeles, Venice", "Canada, Vancouver, Yaletown", "United Kingdom, Manchester, Northern Quarter", "Australia, Melbourne, Fitzroy", "Netherlands, Rotterdam, Delfshaven", "Japan, Osaka, Namba", "South Korea, Busan, Haeundae", "Brazil, Rio de Janeiro, Ipanema", "Mexico, Guadalajara, Chapultepec", "Russia, Saint Petersburg, Nevsky Prospect", "South Africa, Johannesburg, Sandton", "Argentina, Cordoba, Nueva Cordoba", "Chile, Valparaiso, Cerro Alegre", "Peru, Cusco, San Blas", "Colombia, Medellin, El Poblado", "Poland, Gdansk, Old Town", "Greece, Thessaloniki, Ano Poli", "Turkey, Ankara, Kocatepe", "Israel, Haifa, Carmel", "United Arab Emirates, Abu Dhabi, Corniche", "Egypt, Alexandria, Montaza", "Malaysia, Penang, Georgetown", "Singapore, Singapore, Bugis", "Thailand, Chiang Mai, Nimmanhaemin", "Vietnam, Hanoi, Hoan Kiem", "New Zealand, Wellington, Te Aro", "Romania, Cluj-Napoca, Grigorescu", "Czech Republic, Brno, Stare Brno", "Croatia, Split, Varos", "Serbia, Novi Sad, Liman", "Bulgaria, Plovdiv, Kapana", "Ukraine, Lviv, Old City", "Estonia, Tartu, Supilinn", "Latvia, Jurmala, Majori", "Belarus, Brest, Centre", "Kazakhstan, Astana, Left Bank", "Armenia, Gyumri, Kentron", "Georgia, Batumi, Old Batumi", "Kyrgyzstan, Osh, Ak-Suu", "Uzbekistan, Samarkand, Registan", "Turkmenistan, Turkmenbashi, Caspian", "Mongolia, Erdenet, Altanbulag", "Tajikistan, Khujand, Dushanbe", "Azerbaijan, Ganja, City Center", "Lebanon, Tripoli, Al Mina", "Jordan, Aqaba, Tala Bay", "Iraq, Basra, Al Qibla", "Syria, Aleppo, Al Midan", "Afghanistan, Herat, Guzara", "Pakistan, Lahore, Gulberg", "Sri Lanka, Kandy, Peradeniya", "Nepal, Pokhara, Lakeside", "Bangladesh, Chittagong, Bandar", "Norway, Stavanger, Storhaug", "Finland, Oulu, Raksila", "Sweden, Uppsala, Kungsangen", "Denmark, Odense, Hunderup", "Belgium, Ghent, Patershol", "Ireland, Limerick, King Johns Castle", "United States, Chicago, Lincoln Park", "Canada, Montreal, Plateau-Mont-Royal", "United Kingdom, Edinburgh, Old Town", "Australia, Brisbane, West End", "Germany, Munich, Altstadt-Lehel", "France, Lyon, Croix-Rousse", "Italy, Florence, Santa Croce", "Spain, Seville, Santa Cruz", "Netherlands, Utrecht, Oudegracht", "Japan, Kyoto, Gion", "South Korea, Incheon, Bupyeong", "Brazil, Rio de Janeiro, Leblon", "Mexico, Monterrey, San Pedro", "Russia, Yekaterinburg, Vostochny", "Sweden, Malmo, Molleparken", "Norway, Tromso, Storgata", "Finland, Turku, Portsa", "Belgium, Antwerp, Meir", "Austria, Salzburg, Altstadt", "Denmark, Aalborg, Vesterbro", "Portugal, Porto, Ribeira", "Switzerland, Geneva, Eaux-Vives", "India, Delhi, Hauz Khas", "China, Beijing, Chaoyang", "South Africa, Durban, Morningside", "Argentina, Rosario, Echesortu", "Chile, Valdivia, Isla Teja", "Peru, Arequipa, Yanahuara", "Colombia, Medellin, Laureles", "Poland, Poznan, Stare Miasto", "Greece, Thessaloniki, Vardaris", "Turkey, Izmir, Konak", "Israel, Haifa, Neve Sha'anan", "United Arab Emirates, Sharjah, Al Majaz", "Egypt, Alexandria, Bahri", "Malaysia, Kota Kinabalu, Likas", "Singapore, Singapore, Tiong Bahru", "Thailand, Pattaya, Naklua", "Vietnam, Da Nang, My Khe", "New Zealand, Christchurch, Riccarton", "Ireland, Galway, Salthill", "Romania, Timisoara, Unirii", "Hungary, Debrecen, Nagyerdei Park", "Czech Republic, Ostrava, Poruba", "Poland, Wroclaw, Psie Pole", "Slovenia, Maribor, Lent", "Croatia, Zadar, Borik", "Serbia, Nis, Bulevar", "Bulgaria, Varna, Asparuhovo", "Ukraine, Kharkiv, Saltivka", "Estonia, Parnu, Rannapark", "Latvia, Liepaja, Jaunliepaja", "Belarus, Mogilev, Leninsky", "Kazakhstan, Shymkent, Kentau", "Armenia, Vanadzor, Nor Kyugh", "Georgia, Zugdidi, Tsalenjikha", "Kyrgyzstan, Karakol, Dungan", "Uzbekistan, Bukhara, Kogon", "Turkmenistan, Mary, Tazegechak", "Mongolia, Darkhan, Bumbat", "Tajikistan, Khorog, Gorno-Badakhshan", "Azerbaijan, Sumgayit, Hovsan", "Lebanon, Sidon, Ain El-Hilweh", "Jordan, Irbid, Al-Hashimi", "Iraq, Erbil, Ainkawa", "Syria, Homs, Al-Waer", "Afghanistan, Mazar-i-Sharif, Khwaja Rawash", "Pakistan, Islamabad, G-11", "Sri Lanka, Galle, Unawatuna", "Nepal, Lalitpur, Lagankhel", "Bangladesh, Sylhet, Kazir Bazar", "Norway, Lillehammer, Hafjell", "Finland, Kuopio, Karttula", "Sweden, Norrkoping, Ingelsta", "Denmark, Roskilde, Vindinge", "Belgium, Ghent, Gravensteen", "Ireland, Dundalk, Bellinstown", "Italy, Bologna, San Donato", "Germany, Dresden, Neustadt", "Spain, Valencia, Russafa", "United States, Washington, Georgetown", "Canada, Calgary, Inglewood", "United Kingdom, Liverpool, Ropewalks", "Australia, Perth, Northbridge", "Netherlands, The Hague, Scheveningen", "Japan, Fukuoka, Tenjin", "South Korea, Daegu, Dalseo", "Brazil, Sao Paulo, Moema", "Mexico, Tijuana, Zona Rio", "Russia, Kazan, Vakhitovsky", "South Africa, Pretoria, Hatfield", "Argentina, Mendoza, Ciudad", "Chile, Santiago, Bellavista", "Peru, Trujillo, El Porvenir", "Colombia, Cali, San Fernando", "Greece, Crete, Rethymno", "Turkey, Ankara, Bahcelievler", "Israel, Petah Tikva, Kiryat Menahem", "United Arab Emirates, Ajman, Al Nuaimiya", "Egypt, Giza, Mohandessin", "Malaysia, Johor Bahru, Taman Pelangi", "Singapore, Singapore, Clementi", "Thailand, Hua Hin, Khao Takiab", "Vietnam, Hanoi, Ba Dinh", "New Zealand, Dunedin, Mornington", "Romania, Cluj-Napoca, Zorilor", "Croatia, Rijeka, Centar", "Serbia, Novi Sad, Detelinara", "Bulgaria, Sofia, Boyana", "Ukraine, Lviv, Frankivsk", "Estonia, Tartu, Anne", "Belarus, Brest, Partizansky", "Kazakhstan, Aktobe, Akzhar", "Armenia, Yerevan, Arabkir", "Georgia, Tbilisi, Saburtalo", "Kyrgyzstan, Osh, Kyzyl-Kiya", "Uzbekistan, Samarkand, Bibi-Khanym", "Turkmenistan, Ashgabat, Gypjak", "Mongolia, Ulaanbaatar, Bayangol", "Tajikistan, Dushanbe, Shohmansur", "Azerbaijan, Baku, Sabail", "Lebanon, Tripoli, Al-Mina", "Jordan, Amman, Jabal Amman", "Iraq, Sulaymaniyah, Barzani", "Syria, Damascus, Old City", "Afghanistan, Herat, Bala Hesar", "Pakistan, Karachi, Korangi", "Sri Lanka, Colombo, Pettah", "Nepal, Pokhara, Lakeside", "Bangladesh, Chittagong, Patenga"];
    }
}