input = open("input.txt")

left = []
right = []
solution = 0

for line in input:
    line = line.strip().split('   ')
    left.append(int(line[0]))
    right.append(int(line[1]))
    print(line)

left.sort()
right.sort()

for i in range(len(left)):
    solution += abs(left[i] - right[i])

print(solution)


input.close()
