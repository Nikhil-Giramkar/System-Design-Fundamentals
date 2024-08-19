package contracts

type Cache interface {
	Get(key string) string
	Set(key, value string)
	ShowCache() // This will take O(n) time, not used practically, just for demo
}
