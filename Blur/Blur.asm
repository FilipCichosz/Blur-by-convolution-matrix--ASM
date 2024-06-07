.data
    zero dd 0.0          ; Zmienna zero zainicjowana warto�ci� 0.0
    maxes dd 255.0, 255.0, 255.0  ; Tablica maxes z trzema warto�ciami 255.0
    mins dd 0.0, 0.0, 0.0       ; Tablica mins z trzema warto�ciami 0.0

.code

; Procedura wykonuj�ca mno�enie wektor�w xmm0, xmm1 i dodawanie wyniku do xmm2
ASMfuncmul proc 
    movups xmm0, [rcx]  ; Wczytuje wektor xmm0 z pami�ci pod adresem rcx
    movups xmm1, [rdx]  ; Wczytuje wektor xmm1 z pami�ci pod adresem rdx
    movups xmm2, [r8]   ; Wczytuje wektor xmm2 z pami�ci pod adresem r8
    mulps xmm0, xmm1    ; Mno�y xmm0 przez xmm1
    addps xmm2, xmm0    ; Dodaje wynik do xmm2
    movups [r8], xmm2   ; Zapisuje xmm2 z powrotem do pami�ci pod adresem r8
    ret                 ; Zako�czenie procedury
ASMfuncmul endp

; Procedura wykonuj�ca dzielenie wektor�w xmm0 przez xmm1 z ograniczeniem wyniku
ASMfuncdiv proc
    movups xmm0, [rcx]  ; Wczytuje wektor xmm0 z pami�ci pod adresem rcx
    movups xmm1, [rdx]  ; Wczytuje wektor xmm1 z pami�ci pod adresem rdx
    divps xmm0, xmm1    ; Dzieli xmm0 przez xmm1
    movups xmm2, [maxes] ; Wczytuje warto�ci graniczne z tablicy maxes
    minps xmm0, xmm2    ; Ogranicza xmm0 do maksymalnych warto�ci
    movups xmm2, [mins]  ; Wczytuje warto�ci graniczne z tablicy mins
    maxps xmm0, xmm2    ; Ogranicza xmm0 do minimalnych warto�ci
    movups [rcx], xmm0   ; Zapisuje xmm0 z powrotem do pami�ci pod adresem rcx
    ret                 ; Zako�czenie procedury
ASMfuncdiv endp

end