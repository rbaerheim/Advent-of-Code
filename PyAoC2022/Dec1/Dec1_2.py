input = open("input.txt")

temp = 0
carriedList = [] 

for line in input:
    line = line.strip()
    if line == "":
        carriedList.append(temp)
        temp = 0
        continue
    line = int(line)
    temp += line
input.close()

carriedList.sort()
print(carriedList[-1] + carriedList[-2] +carriedList[-3])