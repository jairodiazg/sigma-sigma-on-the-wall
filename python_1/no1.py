def displayMenu():
    print("1 Addition")
    print("2 Subtraction")
    print("3 Multiplication")
    print("4 Division")

def addNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    total = ufirstNum + usecondNum
    print(f"The sum of {ufirstNum} and {usecondNum} is {total}")

def subNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    diff = ufirstNum - usecondNum
    print(f"The difference between {ufirstNum} and {usecondNum} is {diff}")

def multNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    product = ufirstNum * usecondNum
    print(f"The product of {ufirstNum} and {usecondNum} is {product}")

def divNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    if usecondNum == 0:
        print("dividing by zero is not sigma")
    else:
        quotient = ufirstNum / usecondNum
        print(f"The quotient of {ufirstNum} and {usecondNum} is {quotient}")

def main():
    displayMenu()
    uOption = int(input("select a sigma mode: "))

    if uOption == 1:
        addNums()
    elif uOption == 2:
        subNums()
    elif uOption == 3:
        multNums()
    elif uOption == 4:
        divNums()
    else:
        print("Non sigma option. choose a number between 1 and 4")

print("Welcome to the sigma calc (calc is slang for calculator btw)")

main()
