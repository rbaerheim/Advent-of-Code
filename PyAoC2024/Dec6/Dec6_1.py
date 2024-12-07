puzzle_map = []
guard_exit = False
up = True
down = False
right = False
left = False
visited = set()
first_iter = True
solution = 0
exited = 0

import time

t0 = time.time()

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
                visited.add(guard_position)
    matrix_length = len(puzzle_map[0])
    matrix_height = len(puzzle_map)

    for row in range(1, matrix_length - 1):
        for column in range(1, matrix_height - 1):
            visited = set()
            changed = False
            if puzzle_map[row][column] != '#':
                puzzle_map[row][column] = '#'
                changed = True
            guard_exit = False
            while not guard_exit:
                if up:
                    for i in range(matrix_height):
                        if puzzle_map[guard_position[1] - 1][guard_position[2]] == '0':
                            exited += 1
                            guard_exit = True
                            break
                        if puzzle_map[guard_position[1] - 1][guard_position[2]] == '#':
                            guard_position = ("up", guard_position[1], guard_position[2])
                            if guard_position in visited:
                                solution += 1
                                guard_exit = True
                                break
                            visited.add(guard_position)
                            up = False
                            right = True
                            break
                        else:

                            visited.add(guard_position)
                elif right:
                    for i in range(matrix_height):
                        if puzzle_map[guard_position[1]][guard_position[2] + 1] == '0':
                            guard_exit = True
                            exited += 1
                            break
                        if puzzle_map[guard_position[1]][guard_position[2] + 1] == '#':
                            right = False
                            down = True
                            break
                        else:
                            guard_position = ("right", guard_position[1], guard_position[2] + 1)
                            if guard_position in visited:
                                solution += 1
                                guard_exit = True
                                break
                            visited.add(guard_position)
                elif down:
                    for i in range(matrix_height):
                        if puzzle_map[guard_position[1] + 1][guard_position[2]] == '0':
                            guard_exit = True
                            exited += 1
                            break
                        if puzzle_map[guard_position[1] + 1][guard_position[2]] == '#':
                            down = False
                            left = True
                            break
                        else:
                            guard_position = ("down", guard_position[1] + 1, guard_position[2])
                            if guard_position in visited:
                                solution += 1
                                guard_exit = True
                                break
                            visited.add(guard_position)
                elif left:
                    for i in range(matrix_height):
                        if puzzle_map[guard_position[1]][guard_position[2] - 1] == '0':
                            guard_exit = True
                            exited += 1
                            break
                        if puzzle_map[guard_position[1]][guard_position[2] - 1] == '#':
                            left = False
                            up = True
                            break
                        else:
                            guard_position = ("left", guard_position[1], guard_position[2] - 1)
                            if guard_position in visited:
                                solution += 1
                                guard_exit = True
                                break
                            visited.add(guard_position)
            if changed:
                puzzle_map[row][column] = '.'


print(solution) # 5242
t1 = time.time()
print("Exited: ", exited)
print(t1-t0)