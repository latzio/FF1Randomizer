define mapflags $2D
define item_tent $6036
define item_cabin $6037

define MenuRecoverPartyHP $B53F
define MenuSaveConfirm $B2E0
define DrawItemDescBox $B92B
define EnterItemMenu $B11D
define ItemMenu_Loop $B148

UseItem_Tent:
    LDA mapflags            ; ensure we're on the overworld
    LSR A                   ;  shift SM flag into C
    BCS CantUse             ;  if set (in standard map), can't use tent here
    DEC item_tent           ; otherwise... remove 1 tent from the inventory
    LDA #30
	BPL UseItem_TentOrCabin ; Always

UseItem_Cabin:
    LDA mapflags            ; ensure we're on the overworld
    LSR A                   ;  shift SM flag into C
    BCS CantUse             ;  if set (in standard map), can't use tent here
    DEC item_cabin          ; otherwise... remove 1 cabin from the inventory
    LDA #60                 ; Fall thru

UseItem_TentOrCabin:
    JSR MenuRecoverPartyHP  ; give HP to the whole party
    LDA #$1A
    JSR MenuSaveConfirm     ; and bring up confirm save screen (with description text $1A)
    JMP EnterItemMenu       ; then re-enter item menu (need to re-enter, because screen needs full redrawing)

CantUse:
    LDA #$1B                ; if we can't use, just print description text
    JSR DrawItemDescBox
    JMP ItemMenu_Loop       ; and return to loop
