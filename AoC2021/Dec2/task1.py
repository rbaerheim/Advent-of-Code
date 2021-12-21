with open("uboat_coordinates.txt", "r") as plan:
    depth = 0
    position = 0
    aim = 0
    for coordinates in plan:
        coordinates = coordinates.strip().split()
        coordinates[1] = int(coordinates[1])
        if coordinates[0] == "down":
            aim += coordinates[1]
        elif coordinates[0] == "up":
            aim -= coordinates[1]
        elif coordinates[0] == "forward":
            position += coordinates[1]
            depth += (aim * coordinates[1])
plan.close()

result = depth * position

print(depth, position, result)
