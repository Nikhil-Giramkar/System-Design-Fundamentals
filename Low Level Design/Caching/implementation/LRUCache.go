package implementation

import "fmt"

type LRUCache struct {
	store    map[string]string
	dll      *doublyLinkedList
	nodeMap  map[string]node
	capacity int
}

// Get implements contracts.Cache.
func (c LRUCache) Get(key string) string {
	val, isFound := c.store[key]
	if !isFound {
		return key + " - Not in Cache"
	}
	nodeForKey := c.nodeMap[key]
	removedNode := c.dll.detachNode(&nodeForKey)
	c.updateNodeMapForAdjacentNodes(removedNode)
	c.dll.attachNodeToEnd(&nodeForKey)
	c.nodeMap[key] = nodeForKey
	c.updateNodeMapForAdjacentNodes(&nodeForKey)
	return key + " = " + val
}

// Initialize implements contracts.Cache.
func (c *LRUCache) initialize(capacity int) {
	c.capacity = capacity
	c.store = make(map[string]string)
	c.nodeMap = make(map[string]node)
	c.dll = &doublyLinkedList{
		head: nil,
		tail: nil,
	}
}

// Set implements contracts.Cache.
func (c LRUCache) Set(key string, value string) {
	if len(c.store) >= c.capacity {
		removedNode := c.dll.evict()
		c.updateNodeMapForAdjacentNodes(removedNode)
		delete(c.store, removedNode.key)
		delete(c.nodeMap, removedNode.key)
	}
	c.store[key] = value
	newNode := newNode(key)
	tailNode := c.dll.attachNodeToEnd(newNode)
	c.nodeMap[tailNode.key] = *tailNode

	c.updateNodeMapForAdjacentNodes(tailNode)
}

func (c LRUCache) ShowCache() {
	if c.dll.head == nil {
		fmt.Println("Cache empty")
	}
	var cacheList string
	for curr := c.dll.head; curr != nil; curr = curr.next {
		cacheList += "-->" + curr.key
	}
	fmt.Println(cacheList)
}

func (c LRUCache) updateNodeMapForAdjacentNodes(currNode *node) {

	if currNode.prev != nil {
		c.nodeMap[currNode.prev.key] = *currNode.prev
	}

	if currNode.next != nil {
		c.nodeMap[currNode.next.key] = *currNode.next
	}
}
