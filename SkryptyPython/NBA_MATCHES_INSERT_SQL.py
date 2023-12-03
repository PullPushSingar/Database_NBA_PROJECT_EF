

def generate_matches_insert_queries( location, home_team_id, teams,match_id):

    matches_csv = """

    """

    from datetime import datetime


    matches_data = [line.split(',') for line in matches_csv.strip().split('\n')[1:]]

    insert_queries = []

    for match in matches_data:

        match_date = datetime.strptime(match[1].strip(), '%a %b %d %Y').strftime('%Y-%m-%d')
        match_time = match[2].strip()


        opponent_team = match[6].strip()
        if '@' in match[5]:

            home_team_id = home_team_id
            away_team_id = teams.get(opponent_team, None)
        else:

            away_team_id = teams.get(opponent_team, None)

        if home_team_id is None or away_team_id is None:
            continue

        match_time += "m";


        query = f"INSERT INTO Matches (MatchID, Date, Time, Location, HomeTeamID, AwayTeamID) VALUES ({match_id}, '{match_date}', '{match_time}', '{location}', {home_team_id}, {away_team_id});"
        insert_queries.append(query)
        match_id += 1

    return insert_queries

teams_dict = {
    'Atlanta Hawks': 1, 'Boston Celtics': 2, 'Brooklyn Nets': 3, 'Charlotte Hornets': 4,
    'Chicago Bulls': 5, 'Cleveland Cavaliers': 6, 'Dallas Mavericks': 7, 'Denver Nuggets': 8,
    'Detroit Pistons': 9, 'Golden State Warriors': 10, 'Houston Rockets': 11, 'Indiana Pacers': 12,
    'Los Angeles Clippers': 13, 'Los Angeles Lakers': 14, 'Memphis Grizzlies': 15, 'Miami Heat': 16,
    'Milwaukee Bucks': 17, 'Minnesota Timberwolves': 18, 'New Orleans Pelicans': 19, 'New York Knicks': 20,
    'Oklahoma City Thunder': 21, 'Orlando Magic': 22, 'Philadelphia 76ers': 23, 'Phoenix Suns': 24,
    'Portland Trail Blazers': 25, 'Sacramento Kings': 26, 'San Antonio Spurs': 27, 'Toronto Raptors': 28,
    'Utah Jazz': 29, 'Washington Wizards': 30
}

insert_queries_matches = generate_matches_insert_queries( "Capital One Arena", 30, teams_dict,2321)

for query in insert_queries_matches:
    print(query)



