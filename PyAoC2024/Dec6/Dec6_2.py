import time

start = time.time()

puzzle_map = []
visited = set()
first_iter = True
solution = 0

def move_guard(the_map, position):
    if position[0] == "up":
        if the_map[position[1] - 1][position[2]] == "#":
            position = ("right", position[1], position[2])
        else:
            position = ("up", position[1] - 1, position[2])
    elif position[0] == "right":
        if the_map[position[1]][position[2] + 1] == "#":
            position = ("down", position[1], position[2])
        else:
            position = ("right", position[1], position[2] + 1)
    elif position[0] == "down":
        if the_map[position[1] + 1][position[2]] == "#":
            position = ("left", position[1], position[2])
        else:
            position = ("down", position[1] + 1, position[2])
    elif position[0] == "left":
        if the_map[position[1]][position[2] - 1] == "#":
            position = ("up", position[1], position[2])
        else:
            position = ("left", position[1], position[2] - 1)
    return position

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
                guard_position = ("up", x, y)
                initial_guard_position = guard_position
                visited.add(initial_guard_position)

    for i in range(1, len(puzzle_map) - 1):
        for j in range(1, len(puzzle_map[0]) - 1):
            added_block = False
            if puzzle_map[i][j] != '#':
                puzzle_map[i][j] = '#'
                added_block = True
            while True:
                if puzzle_map[guard_position[1]][guard_position[2]] == "0":
                    break
                guard_position = move_guard(puzzle_map, guard_position)
                if guard_position in visited:
                    solution += 1
                    break
                visited.add(guard_position)
            if added_block:
                puzzle_map[i][j] = '.'
                added_block = False
            visited.clear()
            guard_position = initial_guard_position
            visited.add(initial_guard_position)

end = time.time()

print("Solution: ", solution) # 1424
print("Execution time: ", end - start) # 37.05552649497986
