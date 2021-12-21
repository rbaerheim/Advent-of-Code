result1 = 0

result2 = 0

i = 0

j = 0

letterlist = ["a", "b", "c", "d", "e", "f", "g"]

with open("input.txt", "r") as input:
    lines = [line.strip().split("|") for line in input]
    inputValues = [line[0].strip() for line in lines]
    outputValues = [line[1].strip() for line in lines]
    for words in outputValues:
        words = words.split(" ")
        for word in words:
            if 1 < len(word) < 5 or len(word) == 7:
                result1 += 1
    bigList = [line.strip().split(" ") for line in inputValues]
    for smalllists in bigList:
        smalllists = list(sorted(smalllists, key = len, reverse=True))
        while len(smalllists) > 0:
            num = smalllists.pop()
            if len(num) == 2:
                topRight1 = num[0]
                topRight2 = num[1]
                bottomRight1 = num[0]
                bottomRight2 = num[1]
            elif len(num) == 3:
                for letter in num:
                    if letter == topRight1 or letter == topRight2:
                        continue
                    else:
                        top = letter
                        break
            elif len(num) == 4:
                while len(num) > 2:
                    for letter in num:
                        if letter == topRight1 or letter == topRight2:
                            num = num.replace(letter, "")
                            continue
                        topleft1 = num[0]
                        topleft2 = num[1]
                        middle1 = num[0]
                        middle2 = num[1]
            elif len(num) == 5:
                if middle1 in num and topRight1 in num and topRight2 in num:
                    middle = middle1
                    topleft = topleft2
                    for letter in num:
                        if letter != middle and letter != topleft and letter != top and letter != topRight1 and letter != topRight2:
                            bottom = letter
                    for letter in letterlist:
                        if letter != middle and letter != topleft and letter != top and letter != topRight1 and letter != topRight2 and letter != bottom:
                            bottomleft = letter
                elif middle2 in num and topRight1 in num and topRight2 in num:
                    middle = middle2
                    topleft = topleft1
                    for letter in num:
                        if letter != middle and letter != topleft and letter != top and letter != topRight1 and letter != topRight2:
                            bottom = letter
                    for letter in letterlist:
                        if letter != middle and letter != topleft and letter != top and letter != topRight1 and letter != topRight2 and letter != bottom:
                            bottomleft = letter
            elif len(num) == 6:
                if middle in num and topRight1 not in num:
                    topright = topRight1
                    bottomright = bottomRight2
                elif middle in num and topRight2 not in num:
                    topright = topRight2
                    bottomright = bottomRight1
        inputlist = [line.strip().split(" ") for line in outputValues]
        theNumString = ""
        for puts in inputlist[j]:
            if len(puts) == 2:
                theNumString += "1"
            elif len(puts) == 3:
                theNumString += "7"
            elif len(puts) == 4:
                theNumString += "4"
            elif len(puts) == 5:
                if top in puts and topright in puts and middle in puts and bottomleft in puts and bottom in puts:
                    theNumString += "2"
                elif top in puts and topright in puts and middle in puts and bottomright in puts and bottom in puts:
                    theNumString += "3"
                elif top in puts and topleft in puts and middle in puts and bottomright in puts and bottom in puts:
                    theNumString += "5"
            elif len(puts) == 6:
                if top in puts and topleft in puts and middle in puts and bottomright in puts and bottom in puts and bottomleft in puts:
                    theNumString += "6"
                elif top in puts and topleft in puts and middle in puts and bottomright in puts and bottom in puts and topright in puts:
                    theNumString += "9"
                elif top in puts and topleft in puts and bottomleft in puts and bottomright in puts and bottom in puts and topright in puts:
                    theNumString += "0"
            else:
                theNumString += "8"
        intString = int(theNumString)
        result2 += intString
        j += 1
input.close()

print(f"Part 1: {result1}")

print(f"Part 2: {result2}")