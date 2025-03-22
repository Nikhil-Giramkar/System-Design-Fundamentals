package implementation


type node struct {
	next *node
	prev *node
	key  string
}

func newNode(key string) *node {
	return &node{
		next: nil,
		prev: nil,
		key:  key,
	}
}