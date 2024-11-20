# Adds two numbers
def addNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    total = ufirstNum + usecondNum
    print(f"The sum of {ufirstNum} and {usecondNum} is {total}")

# Subtracts two numbers
def subNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    diff = ufirstNum - usecondNum
    print(f"The difference between {ufirstNum} and {usecondNum} is {diff}")

# Multiplies two numbers
def multNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    product = ufirstNum * usecondNum
    print(f"The product of {ufirstNum} and {usecondNum} is {product}")

# Divides two numbers
def divNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    if usecondNum == 0:
        print("Dividing by zero is not allowed.")
    else:
        quotient = ufirstNum / usecondNum
        print(f"The quotient of {ufirstNum} and {usecondNum} is {quotient}")

# Modulo operation
def modNums():
    ufirstNum = float(input("First number: "))
    usecondNum = float(input("Second number: "))
    if usecondNum == 0:
        print("Modulo by zero is not allowed.")
    else:
        remainder = ufirstNum % usecondNum
        print(f"The remainder of {ufirstNum} divided by {usecondNum} is {remainder}")

# Main function with a loop for mode selection
def main():
    modes = ["Addition", "Subtraction", "Multiplication", "Division", "Modulo"]

    print("Here are the modes of the calc (calc is slang for calculator)")

    # Loop for user input
    for i, mode in enumerate(modes, start=1):
        print(f"{i}. {mode}")

    uOption = int(input("Select a mode (1-5): "))

    if uOption == 1:
        addNums()
    elif uOption == 2:
        subNums()
    elif uOption == 3:
        multNums()
    elif uOption == 4:
        divNums()
    elif uOption == 5:
        modNums()
    else:
        print("Invalid option. Please choose a number between 1 and 5.")

print("Welcome to the calc (calc is slang for calculator btw)")

main()
