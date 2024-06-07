.data
    zero dd 0.0          ; Zmienna zero zainicjowana wartoœci¹ 0.0
    maxes dd 255.0, 255.0, 255.0  ; Tablica maxes z trzema wartoœciami 255.0
    mins dd 0.0, 0.0, 0.0       ; Tablica mins z trzema wartoœciami 0.0

.code

; Procedura wykonuj¹ca mno¿enie wektorów xmm0, xmm1 i dodawanie wyniku do xmm2
ASMfuncmul proc 
    movups xmm0, [rcx]  ; Wczytuje wektor xmm0 z pamiêci pod adresem rcx
    movups xmm1, [rdx]  ; Wczytuje wektor xmm1 z pamiêci pod adresem rdx
    movups xmm2, [r8]   ; Wczytuje wektor xmm2 z pamiêci pod adresem r8
    mulps xmm0, xmm1    ; Mno¿y xmm0 przez xmm1
    addps xmm2, xmm0    ; Dodaje wynik do xmm2
    movups [r8], xmm2   ; Zapisuje xmm2 z powrotem do pamiêci pod adresem r8
    ret                 ; Zakoñczenie procedury
ASMfuncmul endp

; Procedura wykonuj¹ca dzielenie wektorów xmm0 przez xmm1 z ograniczeniem wyniku
ASMfuncdiv proc
    movups xmm0, [rcx]  ; Wczytuje wektor xmm0 z pamiêci pod adresem rcx
    movups xmm1, [rdx]  ; Wczytuje wektor xmm1 z pamiêci pod adresem rdx
    divps xmm0, xmm1    ; Dzieli xmm0 przez xmm1
    movups xmm2, [maxes] ; Wczytuje wartoœci graniczne z tablicy maxes
    minps xmm0, xmm2    ; Ogranicza xmm0 do maksymalnych wartoœci
    movups xmm2, [mins]  ; Wczytuje wartoœci graniczne z tablicy mins
    maxps xmm0, xmm2    ; Ogranicza xmm0 do minimalnych wartoœci
    movups [rcx], xmm0   ; Zapisuje xmm0 z powrotem do pamiêci pod adresem rcx
    ret                 ; Zakoñczenie procedury
ASMfuncdiv endp

end