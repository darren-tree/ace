(for [x [1 2 3]
      y [7 8 9]]
  (+ x y))
;; => (8 9 10 9 10 11 10 11 12)

(type (for [x [1 2 3]] x))
;; => clojure.lang.LazySeq