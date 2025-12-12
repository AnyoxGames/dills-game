13
919123001346
3305787959765890 1763178040328223400
{
  "name": "OakTree",
  "local_enabled": true,
  "local_position": {
    "X": 12.8489303588867188,
    "Y": 9.5316104888916016
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405816087092634:1761863511218804100",
  "next_sibling": "3305796328480798:1763178042278135600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "OakTree.prefab"
},
{
  "cid": 3,
  "aoid": "3305787960104859:1763178040328302300",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Oak Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 5,
  "aoid": "3305787960128896:1763178040328307900",
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
},
{
  "cid": 1,
  "aoid": "3305787960163597:1763178040328316000",
  "component_type": "Mono_Component",
  "mono_component_type": "OakTree",
  "data": {
    "Interactable": "3305787960104859:1763178040328302300",
    "DefaultRenderer": "3305787960197051:1763178040328323800",
    "DepletedRenderer": "3305787960184366:1763178040328320900"
  }
}
