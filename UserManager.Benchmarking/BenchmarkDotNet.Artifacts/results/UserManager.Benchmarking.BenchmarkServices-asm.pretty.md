## .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT
```assembly
; UserManager.Benchmarking.BenchmarkServices.GettingHash()
       mov     rcx,qword ptr [rcx+8]
       mov     rdx,221CE8895F8h
       mov     rdx,qword ptr [rdx]
       mov     r8,221CE889600h
       mov     r8,qword ptr [r8]
       mov     rax,7FFDB1AD81E8h
       cmp     dword ptr [rcx],ecx
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       mov     al,byte ptr [4100007FFDB1C3B6h]
       push    rsi
       push    rdi
       push    rsi
       push    rbp
       push    rbx
       sub     rsp,30h
; Total bytes of code 74
```

## .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT
```assembly
; UserManager.Benchmarking.BenchmarkServices.GettingSalt()
       mov     rcx,qword ptr [rcx+8]
       mov     rdx,2096D4F95F8h
       mov     rdx,qword ptr [rdx]
       mov     rax,7FFDB1AE81F0h
       cmp     dword ptr [rcx],ecx
       jmp     rax
       sbb     dword ptr [rax],eax
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       lahf
       ???
       mov     cl,0FDh
       jg      M00_L00
M00_L00:
       add     byte ptr [rdi+56h],dl
       sub     rsp,28h
       mov     rcx,rdx
       call    System.String.IsNullOrWhiteSpace(System.String)
; Total bytes of code 62
```
```assembly
; System.String.IsNullOrWhiteSpace(System.String)
       IL_0000: ldarg.0
       IL_0001: brtrue.s IL_0005
       test    rsi,rsi
       jne     System_Private_CoreLib+0x60876c
       IL_0003: ldc.i4.1
       IL_0004: ret
       mov     eax,1
       add     rsp,20h
       pop     rbx
       pop     rsi
       pop     rdi
       ret
       IL_0005: ldc.i4.0
       IL_0006: stloc.0
       IL_0007: br.s IL_001d
       xor     edi,edi
       IL_001d: ldloc.0
       IL_001e: ldarg.0
       IL_001f: callvirt System.Int32 System.String::get_Length()
       IL_0024: blt.s IL_0009
       mov     ebx,dword ptr [rsi+8]
       test    ebx,ebx
       jle     System_Private_CoreLib+0x6087d1
       IL_0009: ldarg.0
       IL_000a: ldloc.0
       IL_000b: callvirt System.Char System.String::get_Chars(System.Int32)
       IL_0010: call System.Boolean System.Char::IsWhiteSpace(System.Char)
       IL_0015: brtrue.s IL_0019
       movsxd  rcx,edi
       movzx   ecx,word ptr [rsi+rcx*2+0Ch]
       cmp     ecx,0FFh
       jg      System_Private_CoreLib+0x6087af
       cmp     ecx,20h
       je      System_Private_CoreLib+0x6087a8
       lea     edx,[rcx-9]
       cmp     edx,4
       jbe     System_Private_CoreLib+0x6087a8
       cmp     ecx,0A0h
       je      System_Private_CoreLib+0x6087a8
       cmp     ecx,85h
       sete    cl
       movzx   ecx,cl
       jmp     System_Private_CoreLib+0x6087ad
       mov     ecx,1
       jmp     System_Private_CoreLib+0x6087c7
       xor     edx,edx
       call    System.Globalization.CharUnicodeInfo.InternalGetCategoryValue(Int32, Int32)
       add     eax,0FFFFFFF5h
       cmp     eax,2
       ja      System_Private_CoreLib+0x6087c5
       mov     ecx,1
       jmp     System_Private_CoreLib+0x6087c7
       xor     ecx,ecx
       test    ecx,ecx
       je      System_Private_CoreLib+0x6087de
       IL_0019: ldloc.0
       IL_001a: ldc.i4.1
       IL_001b: add
       IL_001c: stloc.0
       inc     edi
       cmp     ebx,edi
       jg      System_Private_CoreLib+0x608775
       IL_0026: ldc.i4.1
       IL_0027: ret
       mov     eax,1
       add     rsp,20h
       pop     rbx
       pop     rsi
       pop     rdi
       ret
       IL_0017: ldc.i4.0
       IL_0018: ret
       xor     eax,eax
; Total bytes of code 134
```

