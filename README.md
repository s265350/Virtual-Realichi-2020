# README Progetto VR Pompei

**NON eseguire commit sul main**

Mantenere la gerarchia attuale delle cartelle:

Blender: modelli e file .blend in generale

References: immagini di riferimento

Documents: Documenti in consegna o da consegnare

Unity: cartella di progetto Unity

Per aprire il progetto su Unity fare Open Project -> ADD -> Selezionate la folder 'Unity'

## Comandi git utili

**git config --global user.name** -> per configurare il proprio username

**git config --global user.email** -> per configurare la propria password

**git init** -> Inizializza un repo locale e si mette sul branch master

**git checkout -b [nomeBranch]** -> switcha, o crea, in locale un nuovo branch

**git clone [url]** -> clona in locale il main branch
**git status** -> Permette di conoscere lo status del proprio branch locale, cosa è committato, cosa no

**git add [fileName]** -> aggiunge il file specificato al commit
**git add .** -> aggiunge tutti i file modificati o aggiunti al commit
**git commit -m "message"** -> inserire commento al commit, e committa in locale

**git push [origin] [branch]** -> pusha il commit sul branch specificato, se il branch non esiste lo crea


**git tag vx.0** -> per taggare la versione 
**git push --tags** -> per pushare i tags locali
**git tag** --> per visualizzare i tags

per ignorare dei file:
.gitignore -> inserire nel file i nomi dei file che voglio ignorare
