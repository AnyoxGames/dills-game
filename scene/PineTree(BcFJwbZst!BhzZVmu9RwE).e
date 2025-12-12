13
4136053506049
404974352571181 1761863315093789700
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 2.4219923019409180,
    "Y": -9.8765974044799805
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404973280063160:1761863314843894100",
  "next_sibling": "404975426058312:1761863315343913400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404974352832320:1761863315093849600",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404974352953924:1761863315093877800",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404974352832320:1761863315093849600",
    "DefaultRenderer": "404974353005008:1761863315093889800",
    "DepletedRenderer": "404974352987593:1761863315093885800"
  }
},
{
  "cid": 5,
  "aoid": "404974352966738:1761863315093880800",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
