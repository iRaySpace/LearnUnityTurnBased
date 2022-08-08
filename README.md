# Unity Turn-based Essentials
- Game System
    - has TMP_Text to indicate whose turn
    - Space for SKIP TURN
    - SetTurn to set if player's turn or enemy's turn.
        - If enemy's turn, start a `Coroutine` to wait for random 3-5 seconds and set to player's turn.
