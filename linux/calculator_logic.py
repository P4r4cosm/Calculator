# calculator_logic.py

import math
from enum import Enum

class Operation(Enum):
    ADD = 0
    SUBTRACT = 1
    MULTIPLY = 2
    DIVIDE = 3
    POWER = 4
    MODULO = 5

class Function(Enum):
    FLOOR = 0
    WITHOUT_ROUND = 1
    CEIL = 2
    SIN = 3
    COS = 4
    SQRT = 5

def do_operation(a: float, b: float, operation: Operation) -> float:
    if operation == Operation.ADD:
        return a + b
    elif operation == Operation.SUBTRACT:
        return a - b
    elif operation == Operation.MULTIPLY:
        return a * b
    elif operation == Operation.DIVIDE:
        return a / b
    elif operation == Operation.POWER:
        return math.pow(a, b)
    elif operation == Operation.MODULO:
        return a % b
    else:
        return a

def do_function(a: float, function: Function) -> float:
    if function == Function.SIN:
        return math.sin(a)
    elif function == Function.COS:
        return math.cos(a)
    elif function == Function.SQRT:
        return math.sqrt(a)
    elif function == Function.FLOOR:
        return math.floor(a)
    elif function == Function.CEIL:
        return math.ceil(a)
    elif function == Function.WITHOUT_ROUND:
        return a
    else:
        return 0
