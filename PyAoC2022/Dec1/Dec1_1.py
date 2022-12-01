input = open("input.txt")

max = 0
temp = 0

for line in input:
    line = line.strip()
    if line == "":
        if max < temp:
            max = temp
        temp = 0
        continue
    temp += int(line)
input.close()

print(max)
# 69626