# JSONC

A solution to parse JSON with comments (JSONC).

## Grammar

The supported characters are letters, numbers, opening and closing brackets and parenthesis and double quotes.

Comments are an exception. They start with // or /* and end with newline or */. Their content can be anything.

The grammar currently supported is described in that file : [Grammar.txt](./Core/Lexicon/Grammar.txt)


## The lexer

It produces tokens from an input string. Tokens are generic and have a type and a value.

It handles format errors the same way as *int.Parse(...)* does: if a character is not recognized, an **UnknownTokenException** is thrown.