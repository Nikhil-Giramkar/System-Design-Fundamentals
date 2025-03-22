package main

import (
	"Caching/implementation"
	"fmt"
)

func main() {
	fmt.Println("Implementing Our own LRU Cache with Capaity as 5")
	myCache := implementation.Initialize_LRU_Cache(5)

	myCache.ShowCache()

	myCache.Set("A", "apple")
	myCache.ShowCache()

	myCache.Set("B", "banana")
	myCache.ShowCache()

	myCache.Set("C", "cherry")
	myCache.ShowCache()

	myCache.Set("D", "date")
	myCache.ShowCache()

	myCache.Set("E", "elderberry")
	myCache.ShowCache()

	myCache.Set("F", "fig")
	myCache.ShowCache()

	myCache.Set("G", "grape")
	myCache.ShowCache()

	myCache.Set("H", "honeydew")
	myCache.ShowCache()

	myCache.Set("I", "ice cream")
	myCache.ShowCache()

	myCache.Set("J", "jackfruit")
	myCache.ShowCache()

	myCache.Set("K", "kiwi")
	myCache.ShowCache()

	val := myCache.Get("K")
	fmt.Println(val)
	myCache.ShowCache()

	val = myCache.Get("I")
	fmt.Println(val)
	myCache.ShowCache()

	val = myCache.Get("G")
	fmt.Println(val)
	myCache.ShowCache()

	val = myCache.Get("D")
	fmt.Println(val)
	myCache.ShowCache()

}
