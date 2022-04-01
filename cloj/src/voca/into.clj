(into #{1 2}
      '(3 4))
;; => #{1 4 3 2}

(into () '(1 2 3))
;; => (3 2 1)

(into [1 2 3] '(4 5 6))
;; => [1 2 3 4 5 6]

(into {:x 4} [{:a 1} {:b 2} {:c 3}])
;; => {:x 4, :a 1, :b 2, :c 3}

(def xform (comp (map #(+ 2 %))
                 (filter odd?)))
(into [-1 -2] xform (range 10))
;; => [-1 -2 3 5 7 9 11]

(into #{} (comp (map #(* 1000 %))
                (map inc))
      [1 2 3])
;; => #{1001 2001 3001}
