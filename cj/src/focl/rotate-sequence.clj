;; https://www.4clojure.com/problem/44

;; 1
(defn abs [n] (if (pos? n) n (* n -1)))
(defn f1 [n coll]
  (let [cnt (count coll)]
    (->> coll
         repeat
         (apply concat)
         (drop (if (pos? n) n (- cnt (rem (abs n) cnt))))
         (take cnt))))
(= (f1 2 [1 2 3 4 5]) '(3 4 5 1 2)) ;; => true
(= (f1 -2 [1 2 3 4 5]) '(4 5 1 2 3)) ;; => true
(= (f1 6 [1 2 3 4 5]) '(2 3 4 5 1)) ;; => true
(= (f1 1 '(:a :b :c)) '(:b :c :a)) ;; => true
(= (f1 -4 '(:a :b :c)) '(:c :a :b)) ;; => true
