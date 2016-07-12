# JSONC

A solution to parse JSON with comments (JSONC).

## Grammar

The supported characters are letters, numbers, opening and closing brackets and parenthesis and double quotes.

Comments are an exception. They start with // or /* and end with newline or */. Their content can be anything.

The grammar currently supported is described in that file : [Grammar.txt](./Core/Lexicon/Grammar.txt)


## The lexer

It produces tokens from an input string. Tokens are generic and have a type and a value.

It handles format errors the same way as *int.Parse(...)* does: if a character is not recognized, an **UnknownTokenException** is thrown.

## Parsing

The goal it to produce an AST that represents the structure of the JSONC, where comments become meta-data to a node of the tree according to the following rules:

- becomes meta-data for the following element
- if there is no following element, becomes meta-data for the containing element

Example:

``` json
{
    // description for the following line
    a = 1,
    b = [1, 2, 3], // description for the following line
    c = {
            /* Long description
                for the following line */
            d = 1,
            e = 2
            // comment for the block
        }
}
```

## Unit tests

The test cases data are provided by the **TestsData** class.
