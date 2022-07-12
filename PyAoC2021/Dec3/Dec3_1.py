def mostOnes(list):
    ones, zeroes = 0, 0
    for numbers in list:
        if numbers == "1":
            ones += 1
        else:
            zeroes += 1
    if ones > zeroes:
        return 1
    else:
        return 0

def mostZeroes(list):
    ones, zeroes = 0, 0
    for numbers in list:
        if numbers == "1":
            ones += 1
        else:
            zeroes += 1
    if ones < zeroes:
        return 1
    else:
        return 0


with open("input.txt", "r") as file:
    one = []
    two = []
    three = []
    four = []
    five = []
    six =  []
    seven = []
    eight = []
    nine = []
    ten = []
    eleven = []
    twelve = []
    resultOnes = []
    resultZeroes = []
    zeroes = 0
    ones = 0
    for numbers in file:
        numbers = numbers.strip().split()
        for number in numbers:
            one.append(number[0])
            two.append(number[1])
            three.append(number[2])
            four.append(number[3])
            five.append(number[4])
            six.append(number[5])
            seven.append(number[6])
            eight.append(number[7])
            nine.append(number[8])
            ten.append(number[9])
            eleven.append(number[10])
            twelve.append(number[11])
    resultOnes.append(mostOnes(one))
    resultOnes.append(mostOnes(two))
    resultOnes.append(mostOnes(three))
    resultOnes.append(mostOnes(four))
    resultOnes.append(mostOnes(five))
    resultOnes.append(mostOnes(six))
    resultOnes.append(mostOnes(seven))
    resultOnes.append(mostOnes(eight))
    resultOnes.append(mostOnes(nine))
    resultOnes.append(mostOnes(ten))
    resultOnes.append(mostOnes(eleven))
    resultOnes.append(mostOnes(twelve))
    resultZeroes.append(mostZeroes(one))
    resultZeroes.append(mostZeroes(two))
    resultZeroes.append(mostZeroes(three))
    resultZeroes.append(mostZeroes(four))
    resultZeroes.append(mostZeroes(five))
    resultZeroes.append(mostZeroes(six))
    resultZeroes.append(mostZeroes(seven))
    resultZeroes.append(mostZeroes(eight))
    resultZeroes.append(mostZeroes(nine))
    resultZeroes.append(mostZeroes(ten))
    resultZeroes.append(mostZeroes(eleven))
    resultZeroes.append(mostZeroes(twelve))

onesString = ""
zerosString = ""

for ones in resultOnes:
    ones = str(ones)
    onesString += ones

for zeros in resultZeroes:
    zeros = str(zeros)
    zerosString += zeros

result = (int(onesString, 2) * int(zerosString, 2))

print(result)
