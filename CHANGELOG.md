# Changelog
## 0.2.2
- Added an extension function to Transform `GetScenePath()`.

## 0.2.1
- Fixed a bug of ref check not waiting at all
- Removed thread-safe lock since it doesn't support multi-threading at the moment.
- Fixed a minor issue about swapped function comments.

## 0.2.0
- Added RefCounter and UnityRefCounter for releasing the resources if there is no references anymore.

## 0.1.0
- Added DisposableBase