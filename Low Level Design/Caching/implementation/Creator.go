package implementation

import "Caching/contracts"

func Initialize_LRU_Cache(capacity int) contracts.Cache {
	lruCache := LRUCache{}
	lruCache.initialize(capacity)
	return lruCache
}
