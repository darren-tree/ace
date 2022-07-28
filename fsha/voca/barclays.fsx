(*
So we thought of having a really easy homework,
but has to be submitted in F#
(single file or paragraph, the submission should just a few lines).
Here is the assignment.
Each new term in the Fibonacci sequence is generated by adding the previous two terms.
By starting with 1 and 2, the first 10 terms will be:
1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
By considering the terms in the Fibonacci sequence whose values do not exceed four million,
find the sum of the even-valued terms.
Please submit the code snippet AND the result; result has the form of a single number.
*)

open System.Collections.Generic

let caching = Dictionary<int, int>()

let memoize f =
    fun x ->
        let existence, value = caching.TryGetValue x
        if existence
        then value
        else let v = f x
             caching.Add(x, v)
             v

let rec fib x =
    match x with
    | 1 | 2 | 3 -> x
    | _ -> fib (x - 1) + fib (x - 2)

(* unit tests
fib 1 = 1 // true
fib 2 = 2 // true
fib 4 = 5 // true
fib 9 = 55 // true
fib 10 = 89 // true *)
    
let fibMemoized = memoize fib

(* unit tests
fibMemoized 1 = 1 // true
fibMemoized 3 = 3 // true
fibMemoized 5 = 8 // true
fibMemoized 9 = 55 // true
fibMemoized 10 = 89 // true *)

let rec getLastIndex f limit i =
    let test = f i < limit &&
               limit < f (i + 1)
    if test then i else getLastIndex f limit (i + 1)

let findLastIndex f limit = getLastIndex f limit 1

(* unit testing
findLastIndex fibMemoized 14 = 6
findLastIndex fibMemoized 60 = 9
findLastIndex fibMemoized 60 = 9 *)

let answer =
    let lastIndex = findLastIndex fibMemoized 4000000
    List.map fibMemoized [1..lastIndex]
    |> List.filter (fun x -> x % 2 = 0)
    |> List.sum

// val answer: int = 4613732