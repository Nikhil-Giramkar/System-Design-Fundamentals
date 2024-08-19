package implementation

//We can use the List package for using doubley linked list - https://pkg.go.dev/container/list
//I created mine for practice purpose

type doublyLinkedList struct {
	head *node
	tail *node
}

func (d *doublyLinkedList) detachNode(toBeRemoved *node) *node {
	if toBeRemoved == nil {
		return toBeRemoved
	}

	if toBeRemoved.prev != nil {
		toBeRemoved.prev.next = toBeRemoved.next
	} else {
		d.head = d.head.next
		d.head.prev = nil
	}

	if toBeRemoved.next != nil {
		toBeRemoved.next.prev = toBeRemoved.prev
	} else {
		d.tail = d.tail.prev
		d.tail.next = nil
	}

	return toBeRemoved
}

func (d *doublyLinkedList) attachNodeToEnd(toobeAttached *node) *node {
	if toobeAttached == nil {
		return toobeAttached
	}

	if d.head == nil {
		d.head = toobeAttached
		d.tail = d.head
		d.head.prev = nil
		d.tail.next = nil
	} else {
		d.tail.next = toobeAttached
		toobeAttached.prev = d.tail
		toobeAttached.next = nil
		d.tail = toobeAttached
	}
	return d.tail

}

func (d *doublyLinkedList) evict() *node {
	if d.head == nil {
		return d.head
	}
	toBeRemoved := d.head
	d.head = d.head.next
	d.head.prev = nil
	return toBeRemoved
}