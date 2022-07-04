//POUr verifie le mot de passe et le nom d'utilisateur
var nom = ['nadhir', 'anis', 'yacine']
var mdp = ['AA', 'BB', 'CC']
var trouve = false;

function valider_login() {
    let nomutil = document.getElementById('username').value;
    let pswdutil = document.getElementById('password').value;
    for (let i = 0; i < 3; i++) {

        if (nomutil == nom[i] || pswdutil == nom[i]) {
            trouve = true;
        }
    }
    if (trouve == true) { console.log('Bienvenue'); } else { console.log('Erreur'); }
}