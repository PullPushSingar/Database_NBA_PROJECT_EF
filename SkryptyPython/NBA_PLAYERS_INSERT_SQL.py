def convert_height_to_cm(feet, inches):

    return int(feet) * 30.48 + int(inches) * 2.54

def convert_weight_to_kg(pounds):

    return int(pounds) * 0.453592

def convert_birth_date(date_string):

    from datetime import datetime
    return datetime.strptime(date_string, "%B %d %Y").strftime("%Y-%m-%d")

def generate_insert_queries(csv_data, team_id, start_player_id):

    data_lines = csv_data.strip().split('\n')[1:]
    queries = []
    player_id = start_player_id

    for line in data_lines:
        player = line.split(',')
        name = player[1].strip()
        position = player[2].strip()
        height_ft_in = player[3].split('-')
        height_cm = round(convert_height_to_cm(height_ft_in[0], height_ft_in[1]))
        weight_kg = round(convert_weight_to_kg(player[4]))
        birth_date = convert_birth_date(player[5])
        nationality = player[6].strip().upper()

        query = f"INSERT INTO Players (PlayerID, TeamID, Name, Position, Height, Weight, BirthDate, Nationality) VALUES ({player_id}, {team_id}, '{name}', '{position}', {height_cm}, {weight_kg}, '{birth_date}', '{nationality}');"
        queries.append(query)
        player_id += 1

    return queries


csv_data_example = """
No.,Player,Pos,Ht,Wt,Birth Date,,Exp,College
1,John Doe,SG,6-4,210,January 1 1990,us,5,Example College
"""
team_id_example = 1
start_player_id_example = 100


insert_queries_example = generate_insert_queries(csv_data_example, team_id_example, start_player_id_example)


for query in insert_queries_example:
    print(query)