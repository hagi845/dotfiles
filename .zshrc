# Ctrl+S がシェルロックに割り当てられているので解除
stty stop undef
stty start undef

alias env='env | sort'

export APP_ENV=production

# 履歴検索をインクリメンタルサーチする
function peco-history-selection() {
    BUFFER=`history -n 1 | tail -r  | awk '!a[$0]++' | peco`
    CURSOR=$#BUFFER
    zle reset-prompt
}
zle -N peco-history-selection
bindkey '^R' peco-history-selection


function find_cd() {
    cd "$(find . -type d | peco)"  
}
alias fc="find_cd"

# git ブランチを一覧表示し、1件選択して checkout する
alias gitb='git branch | peco | awk "{print \$1}" | xargs git c'

# gitブランチ削除
alias gitd='git branch | peco | xargs git branch -D'

# 現在のブランチ this branch
alias tb='git symbolic-ref --short HEAD|tr -d \"\\n\"'
