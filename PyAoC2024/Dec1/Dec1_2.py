input = open("input.txt")

left = []
right = []
solution = 0
similarities = {}

for line in input:
    line = line.strip().split('   ')
    left.append(int(line[0]))
    right.append(int(line[1]))
    print(line)


for i in range(len(left)):
    similarities[left[i]] = 0

for i in range(len(right)):
    if right[i] in similarities:
        similarities[right[i]] += 1

for key, value in similarities.items():
    if value > 0:
        solution += key * value

print(solution)

input.close()
