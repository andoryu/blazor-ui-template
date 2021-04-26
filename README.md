# Blazor UI Template #

Basic template for graphically displaying coding project - via web tools and HTML5 canvas.

## To-dos ##

- [x] basic layout from previus work incorporated and log slider able to be minimised
- [x] updates triggerring action across app
- [x] Canvas component in place and updating
- [X] Disaggregate the facade object into more reasonable parts
- [X] Create test code to run after an event, and perform partial screen updates. (IProgress/Progress)
- [ ] Monitor write sequence of Canvas calls to prevent slow updates (calls over the websocket interface)
- [ ] Get some physical layout data from canvas - JS call?

## Thoughts ##
- Use of IProgress/Progess is not ideal for keep the UI (Blazor) and the algorithms (Travelling Salesman) seperate. Use of the algorithm without the UI will require a mock of IProgress.
- Central state management seems to work well, noting that components need to subscribe to events
- It's not perfect, but it's a start.