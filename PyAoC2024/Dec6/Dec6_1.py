puzzle_map = []
visited = set()
direction = "up"
first_iter = True
solution = 0

def move_guard(the_map, position, current_direction):
    new_direction = current_direction
    if current_direction == "up":
        if the_map[position[0] - 1][position[1]] == "#":
            position = (position[0], position[1])
            new_direction = "right"
        else:
            position = (position[0] - 1, position[1])
    elif current_direction == "right":
        if the_map[position[0]][position[1] + 1] == "#":
            position = (position[0], position[1])
            new_direction = "down"
        else:
            position = (position[0], position[1] + 1)
    elif current_direction == "down":
        if the_map[position[0] + 1][position[1]] == "#":
            position = (position[0], position[1])
            new_direction = "left"
        else:
            position = (position[0] + 1, position[1])
    elif current_direction == "left":
        if the_map[position[0]][position[1] - 1] == "#":
            position = (position[0], position[1])
            new_direction = "up"
        else:
            position = (position[0], position[1] - 1)
    return new_direction, position

with open('input.txt', 'r', encoding='utf-8-sig') as file:
    for line in file:
        if first_iter:
            puzzle_map.append(list("0" * (len(line) + 1)))
            first_iter = False
        puzzle_map.append(list("0" + line.strip() + "0"))
    puzzle_map.append(list("0" * (len(line) + 2)))
    for x, row in enumerate(puzzle_map):
        for y, col in enumerate(row):
            if puzzle_map[x][y] == '^':
                guard_position = (x, y)
                visited.add(guard_position)

    while True:
        direction, guard_position = move_guard(puzzle_map, guard_position, direction)
        if puzzle_map[guard_position[0]][guard_position[1]] == "0":
            break
        visited.add(guard_position)

solution = len(visited)
print(solution) # 5242
