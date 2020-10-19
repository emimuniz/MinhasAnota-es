  //verifica se o parâmetro é o ID2 e adiciona no Id
    if (p.Parameter == "ID2") {
        s.Id = s["ID2"].toString();
        let id = this.state.allIds.filter(f => f.EventTypeId != e.EventTypeId);

        let ids: string[] = [];
        id.forEach(fe => {
            ids = ids.concat(fe.Ids);
        })

        if(ids.filter(f => f == s["ID2"]).length > 0){
            errors = errors.concat(e.EventTypeId + s.IndexDate.toString() + s.Order + s.Name + p.Parameter);
            idError = true;

            if(eventStocks.filter(es=> es == s.Name).length <= 0)
                eventStocks = eventStocks.concat(s.Name);
        }
    } 
