def passe(list):
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
    result = []
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
    result.append(passe(one))
    result.append(passe(two))
    result.append(passe(three))
    result.append(passe(four))
    result.append(passe(five))
    result.append(passe(six))
    result.append(passe(seven))
    result.append(passe(eight))
    result.append(passe(nine))
    result.append(passe(ten))
    result.append(passe(eleven))
    result.append(passe(twelve))




print(result)





            
        

